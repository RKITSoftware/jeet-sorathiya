using File_System.BL;
using File_System.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace File_System.Controllers
{
    /// <summary>
    /// CLEmployeeController for manage Employee Oprations
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        /// <summary>
        /// Object of BLFileOperation
        /// </summary>
        private BLFileOperation _objBLFileOperation;

        public static List<Employee> employeeList = new List<Employee>();

        /// <summary>
        /// Initialize object
        /// </summary>
        public CLEmployeeController()
        {
            _objBLFileOperation = new BLFileOperation();
        }
        

        /// <summary>
        /// Retrieves the list of employees.
        /// </summary>
        /// <returns>HttpResponseMessage containing the list of employees.</returns>
        [HttpGet]
        [Route("EmployeeList")]
        public HttpResponseMessage EmployeeList()
        {
            return Request.CreateResponse(_objBLFileOperation.ReadFromFile());
        }

        /// <summary>
        /// Retrieves details of a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>HttpResponseMessage containing the employee details.</returns>
        [HttpGet]
        [Route("EmployeeDetail/{id}")]
        public HttpResponseMessage EmployeeDetail(int id)
        {
            return Request.CreateResponse(_objBLFileOperation.EmployeeInfo(id));
        }

        /// <summary>
        /// Downloads the file containing employee data.
        /// </summary>
        /// <returns>HttpResponseMessage containing the file for download.</returns>
        [HttpGet]
        [Route("Download")]
        public HttpResponseMessage Download()
        {
            return (_objBLFileOperation.DownloadFile());
        }

        /// <summary>
        /// Adds a new employee to the system.
        /// </summary>
        /// <param name="employee">The employee data to be added.</param>
        /// <returns>HttpResponseMessage indicating the success of the operation.</returns>
        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            employee.EmployeeID = Employee.GetEmployeeID();
            employeeList.Add(employee);
            _objBLFileOperation.AddToFile(employee);
            return Ok(employeeList);
        }

        /// <summary>
        /// Updates data of an existing employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>HttpResponseMessage indicating the success of the operation.</returns>
        [HttpPut]
        [Route("UpdateData/{id}")]
        public IHttpActionResult UpdateData(int id, Employee employee)
        {
            _objBLFileOperation.UpdateEmployeeById(id, employee);
            return Ok();
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>HttpResponseMessage indicating the success of the operation.</returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            _objBLFileOperation.DeleteEmployeeById(id);
            return Ok();
        }


    }
}
