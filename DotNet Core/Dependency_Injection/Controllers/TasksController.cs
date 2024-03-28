using Dependency_Injection.Interface;
using Dependency_Injection.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    /// <summary>
    /// Controller for managing tasks.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskAssignment _taskAssignment;

        /// <summary>
        /// Initializes a new instance of the TasksController class.
        /// </summary>
        /// <param name="taskAssignment">task assignment object.</param>
        public TasksController(ITaskAssignment taskAssignment)
        {
            _taskAssignment = taskAssignment;
        }

        /// <summary>
        /// Retrieves all assignments for a task.
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        /// <returns>assignments for the specified task.</returns>
        [HttpGet("assignments/{taskId}")]
        public ActionResult<IEnumerable<Assignment>> GetAssignmentsForTask(int taskId)
        {
            var assignment = _taskAssignment.GetAssignmentsForTask(taskId);
            return Ok(assignment);
        }

        /// <summary>
        /// Assigns a task to an employee.
        /// </summary>
        /// <param name="taskId">The ID of the task to assign.</param>
        /// <param name="employeeId">The ID of the employee to assign the task to.</param>
        /// <returns>success or failure of the assignment.</returns>
        [HttpPost("assign/{taskId}/{employeeId}")]
        public ActionResult AssignTask(int taskId, int employeeId)
        {
            try
            {
                _taskAssignment.AssignTaskToEmployee(taskId, employeeId);
                return Ok(); // Return 200 OK for successful assignment.
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request with error message.
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError); // Return 500 Internal Server Error for other exceptions.
            }
        }
    }
}
