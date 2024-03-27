using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filter
{
    /// <summary>
    /// Custom result filter for setting response headers.
    /// </summary>
    public class CustomResultFilter : Attribute, IResultFilter
    {
        /// <summary>
        /// Executed after the result is executed.
        /// </summary>
        /// <param name="context">The result executed context.</param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"(CustomResultFilter), OnResultExecuted");

        }

        /// <summary>
        /// Executed before the result is executed.
        /// </summary>
        /// <param name="context">The result executing context.</param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Custom-Header", "JeetFromHeader");
            Console.WriteLine($"(CustomResultFilter), Response Headers Set at OnResultExecuting");
        }
    }
}
