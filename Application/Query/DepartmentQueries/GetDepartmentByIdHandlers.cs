using Application.DTOs.DepartmentDTOs;
using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentByIdHandlers : IRequestHandler<GetDepartmentByIdQuery, ReadDepartmentDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentByIdHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReadDepartmentDTO> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetDepartmentByIdAsync(request.Id);
            if (department == null)
            {
                throw new NotFoundException($"Department with ID {request.Id} not found.");
            }
            ReadDepartmentDTO readDepartmentDTO = _mapper.Map<ReadDepartmentDTO>(department);

            return readDepartmentDTO;
        }
    }
}
