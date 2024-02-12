using CacheClass.BL;
using System.Web.Http;

namespace CacheClass.Controllers
{
    /// <summary>
    /// Controller for managing employee-related actions.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        // Instance of BLEmployee to access employee-related functionality
        private BLEmployee _objbLEmployee;

        /// <summary>
        /// Retrieves the list of employees.
        /// </summary>
        [HttpGet]
        [Route("GetEmployee")]
        public IHttpActionResult GetEmployee()
        {
            // Initialize BLEmployee instance
            _objbLEmployee = new BLEmployee();

            // Retrieve and return the list of employees from BLEmployee
            return Ok(_objbLEmployee.EmployeesList());
        }
    }
}
