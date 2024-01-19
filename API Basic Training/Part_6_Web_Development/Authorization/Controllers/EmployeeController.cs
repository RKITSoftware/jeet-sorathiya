using Authorization.Models;
using Authorization.SEC;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Authorization.Controllers
{
    /// <summary>
    /// Controller for managing employee-related actions.
    /// </summary>
    [RoutePrefix("api/Employee")]
    [BasicAuthenticationAttribute]
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Static list of employees
        /// </summary>
        public static List<Employee> employeeList = new List<Employee>
        {
            new Employee{EmployeeID = 1, EmployeeName = "Jeet", EmployeeRole = "Admin", IsActive = true,  Password = "1234"},
            new Employee{EmployeeID = 2,EmployeeName = "Tony-Stark", EmployeeRole = "Cordinator", IsActive = true, Password = "1234"},
            new Employee{EmployeeID = 3,EmployeeName = "SpiderMan", EmployeeRole = "Trainee", IsActive = !true, Password = "1234"},
            new Employee{EmployeeID = 3,EmployeeName = "hokai", EmployeeRole = "Trainee", IsActive = !true, Password = "1234"},


        };

        /// <summary>
        /// Get all employees. Requires 'Admin' role.
        /// </summary>
        [Route("GetAll")]
        [BasicAuthorizationAttribute(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(employeeList);
        }

        /// <summary>
        /// Get trainee employees. Requires 'Admin' or 'Cordinator' role.
        /// </summary>
        [Route("GetTrainee")]
        [BasicAuthorizationAttribute(Roles = "Admin,Cordinator")]
        [HttpGet]
        public IHttpActionResult GetTrainee()
        {
            List<Employee> employees = new List<Employee>();
            return Ok((employeeList.FindAll(emp => emp.EmployeeRole.Equals("Trainee"))));
        }

        /// <summary>
        /// Get information of the currently logged-in employee. Requires 'Admin', 'Cordinator', or 'Trainee' role.
        /// </summary>
        [Route("GetInfo")]
        [BasicAuthorizationAttribute(Roles = "Admin,Cordinator,Trainee")]
        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            // Get the name of the currently authenticated user
            string name = HttpContext.Current.User.Identity.Name;
            return Ok(employeeList.Find(emp => emp.EmployeeName.Equals(name)));

        }
    }
}
