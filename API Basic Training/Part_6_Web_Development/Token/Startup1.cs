using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Token.TokenAuth;

[assembly: OwinStartup(typeof(Token.Startup1))]

namespace Token
{
    /// <summary>
    /// OWIN Startup class for configuring the application.
    /// </summary>
    public class Startup1
    {
        /// <summary>
        /// Configures the OWIN application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        public void Configuration(IAppBuilder app)
        {
            // Enable Cross-Origin Resource Sharing (CORS) to allow requests from different origins
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Configure OAuth 2.0 authorization server options
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                // Allow insecure HTTP (for development purposes, should be secure in production)
                AllowInsecureHttp = true,
                // Token endpoint path where clients can request access tokens
                TokenEndpointPath = new PathString("/token"), //http://localhost:55970/token
                // Set the token expiration time
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                // Set the custom provider for handling client authentication and resource owner credentials
                Provider = new AuthorizationServerProvider()
            };

            // Use OAuth 2.0 authorization server middleware
            app.UseOAuthAuthorizationServer(options);

            // Use OAuth 2.0 bearer token authentication middleware
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Configure and register the Web API routes
            HttpConfiguration config = new HttpConfiguration();
            //register config to webApi
            WebApiConfig.Register(config);
        }
    }
}
