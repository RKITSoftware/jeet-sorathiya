using System.Web.Http;
using System.Web.Http.Cors;

namespace StockMarket
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Enable CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
