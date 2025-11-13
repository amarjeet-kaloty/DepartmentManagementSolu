using Domain.Interfaces;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class DoesDepartmentExistQueryHandler : IRequestHandler<DoesDepartmentExistQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoesDepartmentExistQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DoesDepartmentExistQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DepartmentRepository.DepartmentExistsAsync(request.DepartmentId);
        }
    }
}
