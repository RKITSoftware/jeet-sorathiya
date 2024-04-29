using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace QueryStringParameter.BAL
{
    /// <summary>
    /// Handle versioning based on query string parameters.
    /// </summary>
    public class QueryStringParameter : DefaultHttpControllerSelector
    {      

        /// <summary>
        /// Constructor for QueryStringParameter class.
        /// </summary>
        /// <param name="config">HttpConfiguration instance.</param>
        public QueryStringParameter(HttpConfiguration config) : base(config)
        {
           
        }

        /// <summary>
        /// Selects the appropriate controller
        /// </summary>
        /// <param name="request">HttpRequestMessage instance.</param>
        /// <returns>HttpControllerDescriptor for the selected controller.</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // Get the mapping of available controllers
            IDictionary<string, HttpControllerDescriptor> allControllers = GetControllerMapping();

            // Get route data from the request
            IHttpRouteData routeData = request.GetRouteData();

            // Extract controller name from route data
            string controllerName = routeData.Values["controller"].ToString();

            string version = "1";

            NameValueCollection queryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

            if (queryString["v"] != null)
            {
                version = queryString["v"];
            }
            if (version == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }

            // Return the selected controller descriptor
            if (allControllers.TryGetValue(controllerName, out HttpControllerDescriptor controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}