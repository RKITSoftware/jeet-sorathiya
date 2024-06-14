using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Lifetime.Interface;

namespace Service_Lifetime.Controllers
{
    /// <summary>
    /// Controller for demonstrating service lifetime.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        #region Private Field
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a instances
        /// </summary>
        /// <param name="transientService">The transient service.</param>
        /// <param name="scopedService">The scoped service.</param>
        /// <param name="singletonService">The singleton service.</param>
        public DemoController(ITransientService transientService,
            IScopedService scopedService,
            ISingletonService singletonService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves the instance ID of the transient service.
        /// </summary>
        /// <returns>The instance ID of the transient service.</returns>
        [HttpGet("transient")]
        public ActionResult<string> GetTransientInstanceId()
        {
            return _transientService.GetInstanceId();
        }

        /// <summary>
        /// Retrieves the instance ID of the scoped service.
        /// </summary>
        /// <returns>The instance ID of the scoped service.</returns>
        [HttpGet("scoped")]
        public ActionResult<string> GetScopedInstanceId()
        {
            return _scopedService.GetInstanceId();
        }

        /// <summary>
        /// Retrieves the instance ID of the singleton service.
        /// </summary>
        /// <returns>The instance ID of the singleton service.</returns>
        [HttpGet("singleton")]
        public ActionResult<string> GetSingletonInstanceId()
        {
            return _singletonService.GetInstanceId();
        } 
        #endregion

    }
}
