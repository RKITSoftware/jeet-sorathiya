using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Filter
{
    /// <summary>
    /// Action filter to log information about action execution.
    /// </summary>
    public class ActionInfoFilter : Attribute,IActionFilter
    {
        private Stopwatch _stopwatch;

        /// <summary>
        /// Executed after the action method.
        /// </summary>
        /// <param name="context">The action executed context.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"(ActionInfoFilter), Task : {Process.GetCurrentProcess().ProcessName} is now Completed\nTotal Time : {_stopwatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Executed before the action method.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew(); // Start the stopwatch.
            Console.WriteLine($"(ActionInfoFilter),  Task : {Process.GetCurrentProcess().ProcessName} now start Executing");
        }
    }
}
