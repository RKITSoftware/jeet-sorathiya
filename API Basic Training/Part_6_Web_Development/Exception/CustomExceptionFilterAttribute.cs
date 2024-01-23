using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Filters;
using System.Web.UI.WebControls;

namespace Exception
{
    /// <summary>
    /// CustomExceptionFilterAttribute is an attribute class that extends ExceptionFilterAttribute in ASP.NET Web API.
    /// It provides a way to handle exceptions globally and modify the HTTP response accordingly.
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Overrides the OnException method to handle exceptions and modify the HTTP response.
        /// </summary>
        /// <param name="context">HttpActionExecutedContext containing information about the executed action and exception.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // Handle the exception and modify the response
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("something wrong"),
                ReasonPhrase = "Internal Problem"
            };
        }
    }
}