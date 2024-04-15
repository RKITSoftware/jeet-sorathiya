using Authorization.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Authorization.SEC
{
    /// <summary>
    /// Custom attribute for basic authentication in Web API.
    /// </summary>
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        BLEmployee _blEmployee;
        /// <summary>
        ///  Initializes a new instance of the BLEmployee class.
        /// </summary>
        public BasicAuthenticationAttribute()
        {
            _blEmployee = new BLEmployee();
        }
        /// <summary>
        /// Overrides the default authorization behavior to perform basic authentication.
        /// </summary>
        /// <param name="actionContext">The context for the action being authorized.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if the Authorization header is present
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login failed");
            }
            else
            {
                // Retrieve the token from the Authorization header
                string token = actionContext.Request.Headers.Authorization.Parameter;

                // Decode the token to get the username and password
                string credential = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] usernamepassword = credential.Split(':');

                string username = usernamepassword[0];
                string password = usernamepassword[1];

                // Validate the login credentials
                if (_blEmployee.Login(username, password))
                {
                    // Retrieve additional user details
                    var employeeDetails = _blEmployee.UserDetails(username, password);

                    // Create a generic identity with the username
                    var identity = new GenericIdentity(username);

                    // Add a claim for the user's name
                    identity.AddClaim(new Claim(ClaimTypes.Name, employeeDetails.EmployeeName));

                    // Create a generic principal with the identity and roles
                    IPrincipal principal = new GenericPrincipal(identity, employeeDetails.EmployeeRole.Split(','));

                    // Set the current principal for the current thread
                    Thread.CurrentPrincipal = principal;

                    // Set the current user for the current HTTP context
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        // If there is no HTTP context, return an unauthorized response
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization Denied");
                    }
                }
                else
                {
                    // If credentials are invalid, return an unauthorized response
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invaild Credentials");
                }
            }
        }
    }
}