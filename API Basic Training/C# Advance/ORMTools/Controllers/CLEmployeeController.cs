using ORMTools.BL;
using ORMTools.Models;
using ORMTools.Models.DTO;
using ORMTools.Models.Enum;
using System.Web.Http;

namespace ORMTools.Controllers
{

    /// <summary>
    /// Controller class for handling employee-related task.
    /// </summary>
    [RoutePrefix("api/CLEmployee")]
    public class CLEmployeeController : ApiController
    {
        private BLEmployee _objBLEmployee;
        private Response _objResponse;

        /// <summary>
        /// Initializes a new instance of the CLEmployeeController class.
        /// </summary>
        public CLEmployeeController()
        {
            _objBLEmployee = new BLEmployee();
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>HTTP response containing the list of employees</returns>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(_objBLEmployee.GetAll());
        }

        /// <summary>
        /// Retrieves employee information by ID from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>HTTP response containing the employee information</returns>
        [HttpGet]
        [Route("GetEmployeeInfo/{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            return Ok(_objBLEmployee.Get(id));
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">DTO object containing employee data</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        [HttpPost]
        [Route("AddEmployee")]
        public Response AddNewEmployee(DTOEMP01 employee)
        {
            _objBLEmployee.Type = EnmType.A;
            _objBLEmployee.PreSave(employee);
            _objResponse = _objBLEmployee.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLEmployee.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates employee data in the database.
        /// </summary>
        /// <param name="employee">DTO object containing updated employee data</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployeeData(DTOEMP01 employee)
        {
            _objBLEmployee.Type = EnmType.E;
            _objBLEmployee.PreSave(employee);
            _objResponse = _objBLEmployee.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLEmployee.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes an employee from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            return _objBLEmployee.Delete(id);
        }
    }
}
