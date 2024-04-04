using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CPContestRegistration.CustomMiddleware
{
    /// <summary>
    /// Middleware for handling request authorization
    /// </summary>
    public class RequestAuthorizationMiddleware : IMiddleware
    {
        private readonly IUserManagement _userManagement;

        /// <summary>
        /// Constructor for RequestAuthorizationMiddleware.
        /// </summary>
        /// <param name="userManagement">User management service instance.</param>
        public RequestAuthorizationMiddleware(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        /// <summary>
        /// Invokes the middleware asynchronously.
        /// </summary>
        /// <param name="context">HTTP context for the request.</param>
        /// <param name="next">Delegate representing the next middleware in the pipeline.</param>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Checks if the endpoint allows anonymous access
            bool hasAllowAnonymous = context.GetEndpoint().Metadata.Any(meta => meta.GetType() == typeof(AllowAnonymousAttribute));

            // If endpoint allows anonymous access, continue to next middleware
            if (hasAllowAnonymous)
            {
                await next(context);
                return;
            }

            // If Authorization header is missing, return Unauthorized status code
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            // Extracts and decodes username and password from Authorization header
            string header = context.Request.Headers["Authorization"].ToString();
            string credential = header.Substring(6);
            string encodingData = Encoding.UTF8.GetString(Convert.FromBase64String(credential));
            string[] userNamePass = encodingData.Split(':');
            string userName = userNamePass[0];
            string password = userNamePass[1];

            // Retrieves users from database
            DataTable Users = _userManagement.SelectAll(true);
            bool IsAuthenticate = false;
            bool IsAdmin = false;
            USE01 user = new USE01();

            foreach (DataRow row in Users.Rows)
            {
                if (row["E01F02"].ToString() == userName && row["E01F04"].ToString() == password)
                {
                    IsAuthenticate = true;
                    user.E01F01 = (int)row["E01F01"];
                    user.E01F02 = row["E01F02"].ToString();
                    user.E01F03 = row["E01F03"].ToString();
                    // Checks if the user is an admin based on email 
                    if (user.E01F03.Contains("@rkit.com"))
                    {
                        IsAdmin = true;
                    }
                    user.E01F04 = row["E01F01"].ToString();
                    break;
                }
            }

            if (!IsAuthenticate)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            // Creates claims for the authenticated user
            var identity = context.User.Identity as ClaimsIdentity;
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.E01F01.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, IsAdmin ? ("Admin") : ("User")));

            // Adds the claims identity to the request context user
            context.User.AddIdentity(identity);

            await next(context);

        }
    }
}
