using DataBase_With_CRUD.BL;
using DataBase_With_CRUD.Models;
using System.Net.Http;
using System.Web.Http;

namespace DataBase_With_CRUD.Controllers
{
    /// <summary>
    /// Controller for managing Employee data through CRUD operations
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        private BLEmployee _objOfBLEmployee;

        /// <summary>
        /// Retrieves all employees
        /// </summary>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            _objOfBLEmployee = new BLEmployee();
            return Ok(_objOfBLEmployee.GetAll());
        }

        /// <summary>
        /// Adds a new employee
        /// </summary>
        /// <param name="employe">Employee data to be added</param>
        [HttpPost]
        [Route("AddNewEmployee")]
        public HttpResponseMessage AddNewEmployee(EMP01 employe)
        {
            _objOfBLEmployee = new BLEmployee();
            return (_objOfBLEmployee.Add(employe));
        }

        /// <summary>
        /// Updates an existing employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="employee">Updated employee data</param>
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public HttpResponseMessage UpdateEmployee(int id, EMP01 employee)
        {
            _objOfBLEmployee = new BLEmployee();
            return (_objOfBLEmployee.Update(id, employee));
        }

        /// <summary>
        /// Deletes an employee by ID
        /// </summary>
        /// <param name="empId">Employee ID to be deleted</param>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public HttpResponseMessage DeleteEmployee(int empId)
        {
            _objOfBLEmployee = new BLEmployee();
            return (_objOfBLEmployee.Delete(empId));
        }

    }
}
