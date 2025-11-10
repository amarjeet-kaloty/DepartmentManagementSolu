using Application.DTOs.ExternalEmployeeDTOs;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Application.DTOs.DepartmentDTOs
{
    public class DepartmentDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<EmployeeReadDTO> Employees { get; set; } = new List<EmployeeReadDTO>();

        [SetsRequiredMembers]
        public DepartmentDetailDTO(Department department, IEnumerable<EmployeeReadDTO> employees)
        {
            Id = department.Id;
            Name = department.Name;
            Description = department.Description;
            Employees = employees;
        }
    }
}
