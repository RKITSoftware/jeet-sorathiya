using Building_Web_API.BL;
using Building_Web_API.Models;
using System.Web.Http;

namespace Building_Web_API.Controllers
{
    /// <summary>
    /// Controller for managing employee data in a Web API.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        private readonly BLEmployee _blEmployee;

        /// <summary>
        /// Constructor for CLEmployeeController.
        /// </summary>
        public CLEmployeeController()
        {
            _blEmployee = new BLEmployee();
        }

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>Returns a list of all employees.</returns>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            // Returning a response with the list of employees
            return Ok(_blEmployee.Get());
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>Returns the employee with the specified ID.</returns>
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            // Returning a response with the employee matching the given ID
            return Ok(_blEmployee.GetByID(id));
        }

        /// <summary>
        /// Retrieves an employee by object.
        /// </summary>
        /// <param name="employee">The employee object to retrieve.</param>
        /// <returns>Returns the retrieved employee object.</returns>
        [HttpGet]
        [Route("GetByObject")]
        public IHttpActionResult Get([FromBody] Employee employee)
        {
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee object to add.</param>
        /// <returns>Returns the added employee object.</returns>
        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult Post(Employee employee)
        {
            if (_blEmployee.Add(employee))
            {
                return Ok(employee);
            }
            else
            {
                return InternalServerError();
            }
        }


        /// <summary>
        /// Updates an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="newEmployee">The updated employee object.</param>
        /// <returns>Returns an HTTP status code indicating the success of the operation.</returns>
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IHttpActionResult Put(int id, Employee newEmployee)
        {
            if (_blEmployee.Update(id, newEmployee))
            {
                return Ok();
            }
            return InternalServerError();
        }


        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>Returns an HTTP status code indicating the success of the operation.</returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (_blEmployee.Delete(id))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
