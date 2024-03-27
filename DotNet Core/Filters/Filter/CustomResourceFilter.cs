using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Filter
{
    /// <summary>
    /// Custom resource filter for logging execution time.
    /// </summary>
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private Stopwatch _stopwatch;

        /// <summary>
        /// Executed after the resource is executed.
        /// </summary>
        /// <param name="context">The resource executed context.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _stopwatch.Stop();
            Console.WriteLine($"(CustomResourceFilter), OnResourceExecuted: End of execution\nTotal Time is {_stopwatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Executed before the resource is executed.
        /// </summary>
        /// <param name="context">The resource executing context.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            Console.WriteLine("(CustomResourceFilter), OnResourceExecuting: Start of execution");
        }
    }
}
