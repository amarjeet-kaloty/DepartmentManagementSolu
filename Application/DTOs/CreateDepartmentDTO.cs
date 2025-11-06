using MediatR;

namespace Application.DTOs
{
    public class CreateDepartmentDTO : IRequest<ReadDepartmentDTO>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
