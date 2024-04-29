using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace CustomHeader.BAL
{
    /// <summary>
    /// Custom HttpControllerSelector to handle versioning based on custom headers.
    /// </summary>
    public class Header : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;

        /// <summary>
        /// Constructor for Header class.
        /// </summary>
        /// <param name="config">HttpConfiguration instance.</param>
        public Header(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// Selects the appropriate controller
        /// </summary>
        /// <param name="request">HttpRequestMessage instance.</param>
        /// <returns>HttpControllerDescriptor for the selected controller.</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // Get the mapping of available controllers
            IDictionary<string, HttpControllerDescriptor> controllers = GetControllerMapping();

            // Get route data from the request
            IHttpRouteData routeData = request.GetRouteData();
            string controllerName = routeData.Values["controller"].ToString();
            string version = "1";

            // Parse version from query string
            NameValueCollection versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

            // Header to check for API version
            string apiHeader = "API-Version";

            // Check if the request headers contain API version information
            if (request.Headers.Contains(apiHeader))
            {
                version = request.Headers.GetValues(apiHeader).FirstOrDefault();               
            }

            // Append version suffix to the controller name
            if (version == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }

            // Return the selected controller descriptor
            if (controllers.TryGetValue(controllerName, out HttpControllerDescriptor controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}