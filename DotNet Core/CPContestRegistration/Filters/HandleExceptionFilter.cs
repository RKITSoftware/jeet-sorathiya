using CPContestRegistration.BL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CPContestRegistration.Filters
{
    /// <summary>
    /// Custom exception filter for handling exceptions.
    /// </summary>
    public class HandleExceptionFilter : IExceptionFilter
    {
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Initializes a new instance of the HandleExceptionFilter class.
        /// </summary>
        /// <param name="loggerService">The logger service.</param>
        public HandleExceptionFilter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _loggerService.ErrorLog(context.Exception);

            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
