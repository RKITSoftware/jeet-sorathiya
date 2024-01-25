using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Test_of_web_development_training.Models;

namespace Test_of_web_development_training.SEC__Security
{
    /// <summary>
    /// Custom authentication attribute for basic authentication in ASP.NET Web API.
    /// </summary>
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Overrides the default authorization behavior to perform basic authentication.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If no authorization header is present, respond with an unauthorized error
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Cheak Headers Is Null");
            }
            else
            {
                // Extract the token from the authorization header
                string token = actionContext.Request.Headers.Authorization.Parameter;

                // Decode the token to get the username and password
                string credential = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] usernamePassword = credential.Split(':');
                string username = usernamePassword[0];
                string password = usernamePassword[1];

                // Check if the provided credentials are valid
                if (User.isUser(username, password))
                {
                    // Get user details from the database
                    User userDetails = User.UserDetails(username);

                    // Create a new identity with the username
                    var identity = new GenericIdentity(username);

                    // Add claims to the identity (in this case, only the user's name)
                    identity.AddClaim(new Claim(ClaimTypes.Name, userDetails.UserName));

                    // Create a new principal with the user's role
                    Thread.CurrentPrincipal = new GenericPrincipal(identity, userDetails.Role.Split(','));

                    // Set the current user for the HttpContext if available
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = Thread.CurrentPrincipal;
                    }
                    else
                    {
                        // If HttpContext is null, respond with an unauthorized error
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization Denied");
                    }
                }
                else
                {
                    // If credentials are invalid, respond with an unauthorized error
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invaild Credentials");

                }


            }
        }
    }
}