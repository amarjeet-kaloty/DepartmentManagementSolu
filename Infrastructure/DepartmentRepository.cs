using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _dbContext;

        public DepartmentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
        }

        public async void UpdateDepartment(Department department)
        {
            _dbContext.Departments.Update(department);
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }
    }
}
