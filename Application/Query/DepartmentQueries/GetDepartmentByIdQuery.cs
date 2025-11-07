using Application.DTOs;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentByIdQuery : IRequest<ReadDepartmentDTO>
    {
        public Guid Id { get; set; }
    }
}
