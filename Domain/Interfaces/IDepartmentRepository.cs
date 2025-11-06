using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task AddDepartmentAsync(Department department);
        public void UpdateDepartment(Department department);
        public Task<Department> GetDepartmentByIdAsync(Guid id);
    }
}
