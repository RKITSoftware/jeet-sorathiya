using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Test_of_web_development_training
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS for all origins, headers, and methods.
            //  var cors = new EnableCorsAttribute("*", "*", "*");
            // config.EnableCors(cors);
           config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
               name: "ApiV1",
               routeTemplate: "api/V1/MarvelCharacter/{id}",
               defaults: new { id = RouteParameter.Optional, Controller = "MarvelCharacterV1" }
           );
            config.Routes.MapHttpRoute(
               name: "ApiV2",
               routeTemplate: "api/V2/MarvelCharacter/{id}",
               defaults: new { id = RouteParameter.Optional, Controller = "MarvelCharacterV2" }
           );
        }
    }
}
