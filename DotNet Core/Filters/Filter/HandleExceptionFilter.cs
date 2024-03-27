using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filter
{
    /// <summary>
    /// Custom exception filter for handling exceptions.
    /// </summary>
    public class HandleExceptionFilter : Attribute, IExceptionFilter
    {
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception (my) : {context.Exception}");

            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
