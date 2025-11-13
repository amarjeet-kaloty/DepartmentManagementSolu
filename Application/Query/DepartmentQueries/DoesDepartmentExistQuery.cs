using MediatR;

namespace Application.Query.DepartmentQueries
{
    public class DoesDepartmentExistQuery : IRequest<bool>
    {
        public Guid DepartmentId { get; set; }

        public DoesDepartmentExistQuery(Guid departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
