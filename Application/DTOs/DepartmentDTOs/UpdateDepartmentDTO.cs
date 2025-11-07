using MediatR;

namespace Application.DTOs.DepartmentDTOs
{
    public class UpdateDepartmentDTO : IRequest<ReadDepartmentDTO>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
