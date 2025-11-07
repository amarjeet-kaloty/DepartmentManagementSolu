using Application.DTOs.DepartmentDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Command.DepartmentCommands
{
    public class CreateDepartmentHandlers : IRequestHandler<CreateDepartmentDTO, ReadDepartmentDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReadDepartmentDTO> Handle(CreateDepartmentDTO request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);
            await _unitOfWork.DepartmentRepository.AddDepartmentAsync(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var readEmployeDTO = _mapper.Map<ReadDepartmentDTO>(department);

            return readEmployeDTO;
        }
    }
}
