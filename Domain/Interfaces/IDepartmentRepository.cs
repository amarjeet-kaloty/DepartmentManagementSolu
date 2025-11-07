using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task AddDepartmentAsync(Department department);
        public void UpdateDepartment(Department department);
        public Task<int> DeleteDepartmentAsync(Guid id);
        public Task<Department> GetDepartmentByIdAsync(Guid id);
        public Task<List<Department>> GetDepartmentListAsync();
    }
}
