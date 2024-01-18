using Authentication.Models;
using Authentication.SEC;
using System.Collections.Generic;
using System.Web.Http;

namespace Authentication.Controllers
{
    /// <summary>
    /// Controller for managing employee data.
    /// </summary>
    public class EmployeeController : ApiController
    {
        // Sample data - a list of employees
        public static List<Employee> employeeList = new List<Employee>
        {
            new Employee { EmployeeID = 1, EmployeeName = "Jeet", EmployeeDesignation = "TeamLead", IsActive = true },
            // Add more employees if needed
        };

        /// <summary>
        /// Retrieves a list of all employees.
        /// Requires authentication.
        /// </summary>
        [Authentication]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(employeeList);
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// Requires authentication.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The requested employee or NotFound if not found.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            // Check if the provided ID is valid
            if (id <= 0 || id > employeeList.Count)
            {
                return NotFound();
            }

            // Retrieve the employee with the specified ID
            Employee requestedEmployee = employeeList[id - 1];
            return Ok(requestedEmployee);
        }
    }
}
