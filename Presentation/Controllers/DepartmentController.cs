using Application.Command.DepartmentCommands;
using Application.DTOs.DepartmentDTOs;
using Application.Query.DepartmentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IMediator mediator, ILogger<DepartmentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Adds a department to the system.
        /// </summary>
        /// <param name="departmentDto">The data transfer object containing the details of the new department to be added.</param>
        /// <returns>
        /// The newly created object, including its assigned ID.
        /// </returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadDepartmentDTO>> AddDepartment([FromBody] CreateDepartmentDTO departmentDto)
        {
            ReadDepartmentDTO newDepartmentDto = await _mediator.Send(departmentDto);
            return Ok(newDepartmentDto);
        }

        /// <summary> 
        /// Updates the existing department in the system.
        /// </summary>
        /// <param name="departmentDto">The data transfer object containing the details of the department to be updated.</param>
        /// <returns>
        /// The updated object.
        /// </returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadDepartmentDTO>> UpdateDepartment([FromBody] UpdateDepartmentDTO departmentDto)
        {
            ReadDepartmentDTO updatedDepartment = await _mediator.Send(departmentDto);
            return Ok(updatedDepartment);
        }

        /// <summary>
        /// Deletes a department in the system.
        /// </summary>
        /// <param name="id">The unique GUID identifier of the department to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> DeleteDepartment(Guid id)
        {
            int departmentDeletedCount = await _mediator.Send(new DeleteDepartmentCommand() { Id = id });
            return Ok(departmentDeletedCount);
        }

        /// <summary>
        /// Retrieves a list of all departments.
        /// </summary>
        /// <returns>
        /// A List of Departments or an empty list if no departmentss are found.
        /// </returns>
        [HttpGet("DepartmentsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ReadDepartmentDTO>>> GetDepartmentList()
        {
            List<ReadDepartmentDTO> departmentList = await _mediator.Send(new GetDepartmentListQuery());
            return Ok(departmentList);
        }

        /// <summary>
        /// Retrieves a specific departent by their unique identifier.
        /// </summary>
        /// <param name="id">The unique GUID identifier of the department to retrieve.</param>
        /// <returns>
        /// An department object corresponding to the provided unique identifier, if one exists.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadDepartmentDTO>> GetDepartment(Guid id)
        {
            ReadDepartmentDTO department = await _mediator.Send(new GetDepartmentByIdQuery() { Id = id });
            return Ok(department);
        }

        /// <summary>
        /// Retrieves a list of employees belonging to a specific department.
        /// </summary>
        /// <param name="id">The unique GUID of the department whose employees are to be retrieved.</param>
        /// <returns>
        /// Department consisting details of all the employees or else an empty list.
        /// </returns>
        [HttpGet("DepartmentDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartmentDetailDTO>> GetDepartmentDetails(Guid id)
        {
            _logger.LogInformation("Department received the request to get all the employees by department ID: {id}.", id);
            var result = await _mediator.Send(new GetDepartmentDetailQuery() { Id = id, UserToken = Request.Headers.Authorization.FirstOrDefault()! });
            return Ok(result);
        }
    }
}
