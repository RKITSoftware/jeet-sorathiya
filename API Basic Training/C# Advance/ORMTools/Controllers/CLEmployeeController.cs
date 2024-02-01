using ORMTools.BL;
using ORMTools.Models;
using System;
using System.Web.Http;

namespace ORMTools.Controllers
{
    /// <summary>
    /// Controller for managing CLEmployee data through CRUD operations.
    /// </summary>
    [RoutePrefix("api/CLEmployee")]
    public class CLEmployeeController : ApiController
    {
        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(BLEmployee.GetAll());
        }

        /// <summary>
        /// Retrieves employee information by ID.
        /// </summary>
        [HttpGet]
        [Route("GetEmployeeInfo/{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            return Ok(BLEmployee.Get(id));
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">Employee data</param>
        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddNewEmployee(EMP01 employee)
        {
            try
            {
                BLEmployee.Add(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Updates employee data.
        /// </summary>
        /// <param name="employee">Updated employee data</param>
        [HttpPut]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployeeData(EMP01 employee)
        {
            try
            {
                BLEmployee.Update(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">Employee ID</param>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                BLEmployee.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
