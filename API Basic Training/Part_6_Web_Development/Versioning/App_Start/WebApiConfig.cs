using System.Web.Http;

namespace Versioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "v1",
                routeTemplate: "api/v1/Employee/{id}",
                defaults: new { id = RouteParameter.Optional, Controller = "CLEmployeeV1" }
            );
            config.Routes.MapHttpRoute(
               name: "v2",
               routeTemplate: "api/v2/Employee/{id}",
               defaults: new { id = RouteParameter.Optional, Controller = "CLEmployeeV2" }
           );
        }
    }
}
