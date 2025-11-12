namespace Domain.Models
{
    public record EmployeeExternalData(
         string Id,
         string Name,
         string Address,
         string Email,
         string Phone,
         int Age,
         decimal Salary,
         bool IsActive,
         DateTime JoiningDate);
}
