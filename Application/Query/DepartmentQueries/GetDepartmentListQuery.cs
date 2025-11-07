using Application.DTOs.DepartmentDTOs;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentListQuery : IRequest<List<ReadDepartmentDTO>>
    {
    }
}
