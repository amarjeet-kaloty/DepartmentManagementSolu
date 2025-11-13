using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task<int> DeleteDepartmentAsync(Guid id)
        {
            _dbContext.Departments.Remove(await _dbContext.Departments.FindAsync(id));
            return 1;
        }

        public async Task<bool> DepartmentExistsAsync(Guid id)
        {
           return await _dbContext.Departments.AnyAsync(department => department.Id == id);
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<List<Department>> GetDepartmentListAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
