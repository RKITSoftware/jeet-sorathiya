using DataBase_With_CRUD.BL;
using DataBase_With_CRUD.Models;
using DataBase_With_CRUD.Models.DTO;
using DataBase_With_CRUD.Models.Enum;
using System.Net.Http;
using System.Web.Http;

namespace DataBase_With_CRUD.Controllers
{

    /// <summary>
    /// Controller for handling employee-related operations.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        private BLEmployee _objOfBLEmployee;
        public Response _objResponse;

        /// <summary>
        /// Constructor for the CLEmployeeController class.
        /// </summary>
        public CLEmployeeController()
        {
            _objOfBLEmployee = new BLEmployee();
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(_objOfBLEmployee.GetAll());
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employe">The employee data to add.</param>
        [HttpPost]
        [Route("AddNewEmployee")]
        public Response AddNewEmployee(DTOEMP01 employe)
        {
            _objOfBLEmployee.Type = EnmType.A;
            _objOfBLEmployee.PreSave(null, employe);
            _objResponse = _objOfBLEmployee.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objOfBLEmployee.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public Response UpdateEmployee(int id, DTOEMP01 employee)
        {
            _objOfBLEmployee.Type = EnmType.E;
            _objOfBLEmployee.PreSave(id, employee);
            _objResponse = _objOfBLEmployee.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objOfBLEmployee.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <param name="empId">The ID of the employee to delete.</param>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public HttpResponseMessage DeleteEmployee(int empId)
        {
            return (_objOfBLEmployee.Delete(empId));
        }

    }
}
