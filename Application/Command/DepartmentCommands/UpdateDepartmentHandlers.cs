using Application.DTOs.DepartmentDTOs;
using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Command.DepartmentCommands
{
    public class UpdateDepartmentHandlers : IRequestHandler<UpdateDepartmentDTO, ReadDepartmentDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReadDepartmentDTO> Handle(UpdateDepartmentDTO request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetDepartmentByIdAsync(request.Id!);
            if (department == null)
            {
                throw new NotFoundException($"Department with ID {request.Id} not found.");
            }
            _mapper.Map(request, department);
            _unitOfWork.DepartmentRepository.UpdateDepartment(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var readDepartmentDTO = _mapper.Map<ReadDepartmentDTO>(department);

            return readDepartmentDTO;
        }
    }
}
