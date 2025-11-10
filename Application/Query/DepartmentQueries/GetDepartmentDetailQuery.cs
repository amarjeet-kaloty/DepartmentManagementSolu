using Application.DTOs.DepartmentDTOs;
using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class GetDepartmentDetailQuery : IRequest<DepartmentDetailDTO>
    {
        public Guid Id { get; set; }

        public required string UserToken { get; set; }
    }
}
