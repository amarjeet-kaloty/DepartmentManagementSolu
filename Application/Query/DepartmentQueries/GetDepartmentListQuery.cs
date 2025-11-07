using Application.DTOs;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentListQuery : IRequest<List<ReadDepartmentDTO>>
    {
    }
}
