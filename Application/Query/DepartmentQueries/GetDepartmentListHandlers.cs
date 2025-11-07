using Application.DTOs;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentListHandlers : IRequestHandler<GetDepartmentListQuery, List<ReadDepartmentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentListHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReadDepartmentDTO>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentList = await _unitOfWork.DepartmentRepository.GetDepartmentListAsync();
            List<ReadDepartmentDTO> readDepartmentDTOList = _mapper.Map<List<ReadDepartmentDTO>>(departmentList);

            return readDepartmentDTOList;
        }
    }
}
