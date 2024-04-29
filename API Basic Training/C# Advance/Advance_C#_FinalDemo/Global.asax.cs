using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Advance_C__FinalDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            OrmLiteConfig.DialectProvider = MySqlDialect.Provider;
            // Database connection using connection string and orm lite tool
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            var dbFactory = new OrmLiteConnectionFactory(connectionString);

            // Storing OrmLiteConnectionFactory instance for further usage in any other component
            Application["DbFactory"] = dbFactory;

            Application["ConnectionString"] = connectionString;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
