using Application.DTOs.DepartmentDTOs;
using MediatR;

namespace Application.Command.DepartmentCommands
{
    public class UpdateDepartmentCommand : IRequest<ReadDepartmentDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public UpdateDepartmentCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
