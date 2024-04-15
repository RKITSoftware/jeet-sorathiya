using Authentication.BL;
using Authentication.SEC;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace Authentication.Controllers
{
    /// <summary>
    /// Controller for managing employee data.
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
        /// Retrieves a list of all employees.
        /// Requires authentication.
        /// </summary>
        [Authentication]
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            System.Diagnostics.Debug.WriteLine(principal.Identity.Name);
            System.Diagnostics.Debug.WriteLine(principal.Identity.AuthenticationType);
            System.Diagnostics.Debug.WriteLine(principal.Identity.IsAuthenticated);

            return Ok(_blEmployee.GetAll());
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The requested employee.</returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_blEmployee.GetByID(id));
        }
    }
}
