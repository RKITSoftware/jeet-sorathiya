using JWT.BL;
using JWT.Models;
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
         BLJWTToken _objBLJWTToken;
        BLEmployee _objBLEMPloyee;
        public CLEmployeeController()
        {
            _objBLJWTToken = new BLJWTToken();
            _objBLEMPloyee = new BLEmployee();
        }

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
            if (!_objBLEMPloyee.IsEmployee(employee))            {
                // Return Unauthorized if the employee is not found
                return Unauthorized();
            }
            // Generate JWT token for the employee
            string token = _objBLJWTToken.GenerateToken(employee.EmployeeName);

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
            // Verify the JWT token and extract the employee name
            string employeeName = _objBLJWTToken.VerifyToken(token);
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
