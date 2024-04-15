using Authorization.BL;
using Authorization.SEC;
using System.Web.Http;

namespace Authorization.Controllers
{
    /// <summary>
    /// Controller for managing employee-related actions.
    /// </summary>
    [RoutePrefix("api/Employee")]
    [BasicAuthentication]
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
        /// Get all employees. Requires 'Admin' role.
        /// </summary>
        [Route("GetAll")]
        [BasicAuthorization(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_blEmployee.GetAll());
        }

        /// <summary>
        /// Get trainee employees. Requires 'Admin' or 'Cordinator' role.
        /// </summary>
        [Route("GetTrainee")]
        [BasicAuthorization(Roles = "Admin,Cordinator")]
        [HttpGet]
        public IHttpActionResult GetTrainee()
        {
            return Ok(_blEmployee.GetAllTrainee());
        }

        /// <summary>
        /// Get information of the currently logged-in employee. Requires 'Admin', 'Cordinator', or 'Trainee' role.
        /// </summary>
        [Route("GetInfo")]
        [BasicAuthorization(Roles = "Admin,Cordinator,Trainee")]
        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            return Ok(_blEmployee.GetInfo());
        }
    }
}
