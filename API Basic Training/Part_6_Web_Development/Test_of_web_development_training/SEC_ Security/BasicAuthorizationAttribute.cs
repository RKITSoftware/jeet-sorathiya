using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Test_of_web_development_training.SEC__Security
{
    /// <summary>
    /// Custom authorization attribute for basic authentication in ASP.NET Web API.
    /// </summary>
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Handles unauthorized requests by responding with either a forbidden status or the base behavior if the user is authenticated.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            // Check if the user is authenticated
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // If authenticated, use the base behavior for unauthorized requests
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                // If not authenticated, respond with a forbidden status
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
}