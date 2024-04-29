using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace DataBase_With_CRUD
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Database connection using connection string and orm lite tool.
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            Application["ConnectionString"] = connectionString;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
