using Application.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Command.DepartmentCommands
{
    public class DeleteDepartmentHandlers : IRequestHandler<DeleteDepartmentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepartmentHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.DepartmentRepository.GetDepartmentByIdAsync(request.Id);
            if (department == null)
            {
                throw new NotFoundException($"Department with ID {request.Id} not found.");
            }
            await _unitOfWork.DepartmentRepository.DeleteDepartmentAsync(request.Id);
            int affectedRows = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return affectedRows;
        }
    }
}
