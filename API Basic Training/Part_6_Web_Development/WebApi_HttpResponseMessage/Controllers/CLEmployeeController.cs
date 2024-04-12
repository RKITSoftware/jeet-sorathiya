using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_HttpResponseMessage.BL;
using WebApi_HttpResponseMessage.Models;

namespace WebApi_HttpResponseMessage.Controllers
{
    /// <summary>
    /// Controller for managing employee data in a Web API.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        BLEmployee _blEmployee;
        /// <summary>
        /// Initializes a new instance of the BLEmployee class.
        /// </summary>
        public CLEmployeeController()
        {
            _blEmployee = new BLEmployee();
        }


        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>Returns a response message with the list of employees.</returns>
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            // Returning a response with the list of employees
            return Request.CreateResponse(HttpStatusCode.OK, _blEmployee.Get());
        }


        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>Returns a response message with the employee matching the given ID.</returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public HttpResponseMessage Get(int id)
        {
            // Returning a response with the employee matching the given ID
            return Request.CreateResponse(HttpStatusCode.OK, _blEmployee.GetById(id));
        }


        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>Returns a response message with the updated list of employees.</returns>
        [HttpPost]
        [Route("AddEmployee")]
        public HttpResponseMessage Post(Employee employee)
        {
            // Returning a response with the updated list of employees
            return Request.CreateResponse(HttpStatusCode.OK, _blEmployee.Add(employee));
        }


        /// <summary>
        /// Updates an employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="newEmployee">The updated employee.</param>
        /// <returns>Returns a response message with the updated employee.</returns>
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public HttpResponseMessage Put(int id, Employee newEmployee)
        {
            Employee response = _blEmployee.Update(id, newEmployee);

            if (response != null)
            {
                // Returning a response with the updated employee
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>Returns a response message indicating the success of the operation.</returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool isDeleted = _blEmployee.Delete(id);
            if (isDeleted)
            {
                // Returning a response with the deleted employee
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
