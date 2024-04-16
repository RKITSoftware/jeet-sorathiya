using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Exception
{
    /// <summary>
    /// Custom exception filter attribute for handling exceptions
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Handles the exception and modifies the response.
        /// </summary>
        /// <param name="context">The context of the HttpActionExecutedContext</param>
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