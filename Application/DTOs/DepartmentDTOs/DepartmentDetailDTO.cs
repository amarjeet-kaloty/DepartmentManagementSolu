using Application.DTOs.ExternalEmployeeDTOs;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Application.DTOs.DepartmentDTOs
{
    public class DepartmentDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<EmployeeReadDTO> Employees { get; set; } = new List<EmployeeReadDTO>();

        public DepartmentDetailDTO(Department department, IEnumerable<EmployeeReadDTO> employees)
        {
            Id = department.Id;
            Name = department.Name;
            Description = department.Description;
            Employees = employees;
        }
    }
}
