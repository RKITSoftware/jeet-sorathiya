using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Authorization.SEC
{
    /// <summary>
    /// Custom attribute for basic authorization in Web API.
    /// </summary>
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Handles the unauthorized request by either allowing it (if the user is authenticated) or returning a forbidden status.
        /// </summary>
        /// <param name="actionContext">The context for the action being authorized.</param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            // Check if the user is authenticated
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // If authenticated, let the base class handle the unauthorized request
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                // If not authenticated, return a forbidden status
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
}