
namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 
    }
}
