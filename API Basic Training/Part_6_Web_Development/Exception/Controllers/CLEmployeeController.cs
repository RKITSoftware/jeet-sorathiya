using Exception.BL;
using System.Web.Http;

namespace Exception.Controllers
{
    /// <summary>
    /// Controller for managing employee-related actions.
    /// </summary>
    [RoutePrefix("api/Employee")]
    [CustomExceptionFilter]
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
        /// Get all employees.
        /// </summary>
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
           return Ok(_blEmployee.GetAll());
        }

        /// <summary>
        /// Get trainee employees.
        /// </summary>
        [Route("GetTrainee")]
        [HttpGet]
        public IHttpActionResult GetTrainee()
        {
            return Ok(_blEmployee.GetAllTrainee());
        }

        /// <summary>
        /// Get information of the currently logged-in employee.
        /// </summary>
        [Route("GetInfo")]
        [HttpGet]      
        public IHttpActionResult GetInfo()
        {
           return Ok(_blEmployee.GetInfo());
        }
    }
}
