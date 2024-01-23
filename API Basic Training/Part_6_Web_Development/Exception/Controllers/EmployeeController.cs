using Exception.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Exception.Controllers
{
    /// <summary>
    /// Controller for managing employee-related actions.
    /// </summary>
    [RoutePrefix("api/Employee")]

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
        /// Get all employees.
        /// </summary>
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            if(employeeList.Count == 0)
            {
                return InternalServerError();
            }
            return Ok(employeeList);
        }

        /// <summary>
        /// Get trainee employees.
        /// </summary>
        [Route("GetTrainee")]
        [HttpGet]
        public HttpResponseMessage GetTrainee()
        {
            List<Employee> employees = new List<Employee>();
            employeeList.FindAll(emp => emp.EmployeeRole.Equals("Trainee"));
            if (employeeList.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "something wrong ontact Admin");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        /// <summary>
        /// Get information of the currently logged-in employee.
        /// </summary>
        [Route("GetInfo")]
        [HttpGet]
        [CustomExceptionFilterAttribute]
        public IHttpActionResult GetInfo()
        {
            // Get the name of the currently authenticated user
            string name = HttpContext.Current.User.Identity.Name;
            employeeList.Find(emp => emp.EmployeeName.Equals(name));
            if(employeeList.Count == 0)
            {
                throw new System.Exception();
            }
            return Ok();

        }
    }
}
