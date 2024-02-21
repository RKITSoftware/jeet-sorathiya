using Advance_C__FinalDemo.BL;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling administrative actions
    /// </summary>
    [RoutePrefix("Api/Admin")]
    public class CLAdminController : ApiController
    {
        /// <summary>
        /// Initiates the backup process for data.
        /// </summary>
        /// <returns>
        /// IHttpActionResult with HTTP 200 OK status for successful backup, 
        /// or HTTP 500 Internal Server Error for backup failure.
        /// </returns>
        [HttpGet]
        [Route("Backup")]
        public IHttpActionResult BackupData()
        {
            BLData objOfBLData = new BLData();
            bool response = objOfBLData.Backup();

            if (response)
            {
                // Return HTTP 200 OK status for successful backup
                return Ok();
            }
            else
            {
                // Return HTTP 500 Internal Server Error for backup failure
                return InternalServerError();
            }
        }
    }
}
