using Advance_C__FinalDemo.BL.Service;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.POCO;
using System;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling user authentication.
    /// </summary>
    [RoutePrefix("api/CLAuthentication")]
    [AllowAnonymous]
    public class CLAuthenticationController : ApiController
    {
        #region Private Fields
        private BLUSR01 _blUser;
        private BLToken _blToken;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CLAuthenticationController"/> class.
        /// </summary>
        public CLAuthenticationController()
        {
            _blUser = new BLUSR01();
            _blToken = new BLToken();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates a token for a user based on username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>An HTTP response with a token if credentials are valid, otherwise an error message.</returns>
        [HttpGet]
        [Route("Generate")]
        public IHttpActionResult GenerateToken(string username, string password)
        {
            Response response = new Response();

            USR01 objUser = _blUser.GetUser(username, password);

            if (objUser != null)
            {
                response.Data = _blToken.GenerateToken(Guid.NewGuid(), objUser);
            }
            else
            {
                response.IsError = true;
                response.Message = "Credentials are invalid.";
            }

            return Ok(response);
        } 
        #endregion
    }
}
