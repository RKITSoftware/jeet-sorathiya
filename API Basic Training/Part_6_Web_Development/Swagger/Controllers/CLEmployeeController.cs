using Swagger.BL;
using Swagger.Models;
using System.Web.Http;

namespace Swagger.Controllers
{
    /// <summary>
    /// Controller for managing Employee operations.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        BLEmployee _blEmployee;

        /// <summary>
        ///  Initializes a new instance of the BLEmployee class.
        /// </summary>
        public CLEmployeeController()
        {
            _blEmployee = new BLEmployee();
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(_blEmployee.GetAll());
        }

        /// <summary>
        /// Gets details of a specific employee.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        [HttpGet]
        [Route("GetEmployeeDetail")]
        public IHttpActionResult GetEmployeeDetail(int id)
        {
            return Ok(_blEmployee.GetById(id));
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="newEmployee">Employee object to add.</param>
        [HttpPost]
        [Route("AddNewEmployee")]
        public IHttpActionResult AddNewEmployee(Employee newEmployee)
        {
            return Ok(_blEmployee.Add(newEmployee));
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">Employee ID to delete.</param>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            return Ok(_blEmployee.Delete(id));
        }

        /// <summary>
        /// Updates details of an existing employee.
        /// </summary>
        /// <param name="id">Employee ID to update.</param>
        /// <param name="newEmployee">Updated Employee object.</param>
        [HttpPut]
        [Route("UpdateDetails")]
        public IHttpActionResult UpdateDetails(int id, Employee newEmployee)
        {

            return Ok(_blEmployee.Update(id, newEmployee));
        }
    }
}
