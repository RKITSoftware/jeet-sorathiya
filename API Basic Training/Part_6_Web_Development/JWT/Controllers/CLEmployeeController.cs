using JWT.BL;
using JWT.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace JWT.Controllers
{
    /// <summary>
    /// Controller for managing employee-related actions.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        // Business logic class for JWT token generation and verification
        private BLJWTToken objBLJWTToken;

        /// <summary>
        /// Static list of employees
        /// </summary>
        public static List<Employee> employeeList = new List<Employee>
        {
            new Employee{EmployeeName = "Jeet",Password = "1234"},
            new Employee{EmployeeName = "Tony-Stark", Password = "1234"},
            new Employee{EmployeeName = "SpiderMan", Password = "1234"},
            new Employee{EmployeeName = "hokai", Password = "1234"},


        };

        /// <summary>
        /// Generates a JWT token for the provided employee credentials.
        /// </summary>
        /// <param name="employee">The employee credentials.</param>
        /// <returns>JWT token if the employee is authenticated, otherwise Unauthorized.</returns>
        [Route("GenerateToken")]
        [HttpPost]
        public IHttpActionResult JWTToken(Employee employee)
        {
            // Check if the employee exists in the static list
            bool isEmployee = employeeList.Any(emp => emp.EmployeeName == employee.EmployeeName && emp.Password == employee.Password);
            if (!isEmployee)
            {
                // Return Unauthorized if the employee is not found
                return Unauthorized();
            }

            // Initialize the BLJWTToken object for token generation
            objBLJWTToken = new BLJWTToken();

            // Generate JWT token for the employee
            string token = objBLJWTToken.GenerateToken(employee.EmployeeName);

            // Return the generated token
            return Ok(token);
        }

        /// <summary>
        /// Verifies a JWT token and returns the associated employee name.
        /// </summary>
        /// <param name="token">The JWT token to verify.</param>
        /// <returns>Employee name if the token is valid, otherwise Unauthorized.</returns>
        [Route("VerifyJWT")]
        [HttpGet]
        public IHttpActionResult VerifyJWT(string token)
        {
            // Initialize the BLJWTToken object for token verification
            objBLJWTToken = new BLJWTToken();

            // Verify the JWT token and extract the employee name
            string employeeName = objBLJWTToken.VerifyToken(token);
            if (employeeName == null)
            {
                // Return Unauthorized if token verification fails
                return Unauthorized();
            }
            // Return the verified employee name
            return Ok(employeeName);
        }
    }
}
