using MediatR;

namespace Application.Command.DepartmentCommands
{
    public class DeleteDepartmentCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
