using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Authentication.SEC
{
    /// <summary>
    /// Attribute for authenticating user requests based on Authorization headers.
    /// </summary>
    public class AuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Validates the Authorization header and sets the current principal if authentication is successful.
        /// </summary>
        /// <param name="actionContext">The context for the HTTP action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                // No Authorization header provided, return Unauthorized
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Login fail");
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;

                string token = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] loginCredentials = token.Split(':');
                string username = loginCredentials[0];
                string password = loginCredentials[1];

                if (ValidateUser.Login(username, password))
                {
                    // Authentication successful, set the current principal
                    IIdentity identity = new GenericIdentity(username, "BASIC");
                    Thread.CurrentPrincipal = new GenericPrincipal(identity,null);
                }
                else
                {
                    // Authentication failed, return Unauthorized
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Login fail");
                }
            }
        }
    }
}
