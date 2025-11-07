using Application.DTOs.DepartmentDTOs;
using MediatR;

namespace Application.Command.DepartmentCommands
{
    public class CreateDepartmentCommand : IRequest<ReadDepartmentDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateDepartmentCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
