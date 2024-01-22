using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Token.TokenAuth
{
    /// <summary>
    /// Custom OAuth Authorization Server Provider for handling client authentication and resource owner credentials.
    /// </summary>
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Validates the client's authentication during the OAuth 2.0 token request.
        /// </summary>
        /// <param name="context">The context used for validating client authentication.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // For simplicity, this example approves all client authentication.
            context.Validated();
        }

        /// <summary>
        /// Grants resource owner credentials and issues an access token.
        /// </summary>
        /// <param name="context">The context containing the resource owner credentials.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Custom validation logic using the 'Validation' class to check user credentials
            Validation objofValidation = new Validation();
            var employee = objofValidation.EmployeeDetail(context.UserName, context.Password);
            // If the user is not valid, set an error and return
            if (employee == null)
            {
                context.SetError("invalid_grant", "Username or Password is incorrect");
                return;
            }

            // Create an identity for the authenticated user
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            // Add user roles as claims
            foreach (var role in employee.EmployeeRole.Split(','))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
            }

            // Validate and issue the access token
            context.Validated(identity);
        }
    }
}