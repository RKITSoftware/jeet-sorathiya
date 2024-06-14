using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Advance_C__FinalDemo.Attribute
{
    /// <summary>
    /// Custom authorization attribute for Bearer Token Authentication.
    /// </summary>
    public class BearerAuthAttribute : AuthorizationFilterAttribute
    {
        #region Public Methods

        /// <summary>
        /// Overrides the default OnAuthorization method to perform Bearer Token Authentication.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (!CheckAllowAnonymousAttribute(actionContext))
                {
                    string token = actionContext.Request.Headers.Authorization?.ToString();

                    // Checking if Token is provided
                    if (string.IsNullOrEmpty(token))
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        return;
                    }

                    string issuer = "CustomJWTBearerTokenAPI";
                    string seceretKey = "thisissecuritykeyofcustomjwttokenaut";

                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(seceretKey));
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                    TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = issuer,
                        ValidIssuer = issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey,
                        LifetimeValidator = LifetimeValidator
                    };

                    ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                        tokenValidationParameters, out SecurityToken _objSecurityToken);

                    if (principal != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Checks the AllowAnonymous Attribute Exists or not.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        /// <returns>True if exists else false.</returns>
        private bool CheckAllowAnonymousAttribute(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        /// <summary>
        /// validate wether token expiers or not
        /// </summary>
        /// <param name="notBefore"></param>
        /// <param name="expires">Token expire time</param>
        /// <param name="securityToken"></param>
        /// <param name="tokenValidationParameters"></param>
        /// <returns> if : expiers then true else : false </returns>
        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters tokenValidationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires)
                    return true;
            }
            return false;
        }

        #endregion Private Methods
    }
}