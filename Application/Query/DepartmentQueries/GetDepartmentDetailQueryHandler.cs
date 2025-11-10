using Application.DTOs.DepartmentDTOs;
using Application.DTOs.ExternalEmployeeDTOs;
using AutoMapper;
using Domain.Interfaces;
using Domain.Service;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentDetailQueryHandler : IRequestHandler<GetDepartmentDetailQuery, DepartmentDetailDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public GetDepartmentDetailQueryHandler(
            IUnitOfWork unitOfWork,
            IEmployeeService employeeService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<DepartmentDetailDTO> Handle(GetDepartmentDetailQuery request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetDepartmentByIdAsync(request.Id);
            if (department == null) return null!;

            // Service Invocation call
            var employees = await _employeeService.GetEmployeesByDepartmentIdAsync(request.Id, request.UserToken);

            var employeesForResponse = _mapper.Map<IEnumerable<EmployeeReadDTO>>(employees);
            return new DepartmentDetailDTO(department, employeesForResponse);
        }
    }
}
