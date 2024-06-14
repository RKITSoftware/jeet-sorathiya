using CPContestRegistration.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CPContestRegistration.Filters
{
    /// <summary>
    /// Custom authorization attribute for role-based access control.
    /// </summary>
    public class MyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        #region Public Field
        /// <summary>
        /// Gets or sets the roles that are allowed to access the resource.
        /// </summary>
        public string Roles { get; set; } 
        #endregion

        #region Public Methods
        /// <summary>
        /// Called to authorize a request based on user roles.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userRole = context.HttpContext.User.GetRole();
            bool isAuthorize = false;

            string[] rolesArr = Roles.Split(',');
            foreach (string role in rolesArr)
            {
                if (role.Equals(userRole))
                {
                    isAuthorize = true;
                    break;
                }
            }

            if (!isAuthorize)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        } 
        #endregion
    }
}
