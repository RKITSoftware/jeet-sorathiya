using Logging.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    /// <summary>
    /// Controller for managing employee-related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Registers a new employee
        /// </summary>
        /// <param name="employee">The employee details</param>
        /// <returns>IActionResult with status</returns>
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] Employee employee)
        {
            try
            {
                if (employee.Id <= 99 || employee.Id > 999)
                {
                    throw new Exception("Id Invalid");
                }

                // Log registration success
                _logger.Info($"User {employee.Username} registered successfully");

                return Ok($"User {employee.Username} registered successfully");
            }
            catch (Exception ex)
            {
                // Log registration failure
                _logger.Error(ex, $"Error registering user {employee.Username}");
                return StatusCode(500, "An error occurred while registering the user.");
            }
        }
    }
}
