﻿using Advance_C__FinalDemo.Attribute;
using Advance_C__FinalDemo.BL;
using System.Web.Http;

namespace Advance_C__FinalDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new LoggingExceptionFilterAttribute());
            config.Filters.Add(new BearerAuthAttribute());
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
