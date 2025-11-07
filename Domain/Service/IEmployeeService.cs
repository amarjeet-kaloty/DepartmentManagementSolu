using Domain.Models;

namespace Domain.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeExternalData>> GetEmployeesByDepartmentIdAsync(Guid departmentId);
    }
}
