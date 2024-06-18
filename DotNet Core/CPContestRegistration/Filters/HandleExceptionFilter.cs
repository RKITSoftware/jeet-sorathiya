using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models.POCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using NLog.Config;
using NLog.Targets;
using ServiceStack.Logging;
using System.Security.Claims;

namespace CPContestRegistration.Filters
{
    /// <summary>
    /// Custom exception filter for handling exceptions.
    /// </summary>
    public class HandleExceptionFilter : IExceptionFilter
    {
        #region Private Field
        private readonly ILoggerService _loggerService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the HandleExceptionFilter class.
        /// </summary>
        /// <param name="loggerService">The logger service.</param>
        public HandleExceptionFilter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _loggerService.ErrorLog(context.Exception);

            var config = NLog.LogManager.Configuration ?? new LoggingConfiguration();

            string fileName = context.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            string path = "${currentdir}/logs/" + fileName + ".log";

            var existingTarget = config.FindTargetByName("users") as FileTarget;
            if (existingTarget != null)
            {
                existingTarget.FileName = path;
            }
            else
            {
                var fileTarget = new FileTarget("users")
                {
                    FileName = path,
                    Layout = "${longdate} ${uppercase:${level}} ${message}"
                };  
               config.AddTarget(fileTarget);
                var rule = new LoggingRule("*", NLog.LogLevel.Error, fileTarget);
                config.LoggingRules.Add(rule);
            }
            NLog.LogManager.Configuration = config;

            NLog.LogManager.ReconfigExistingLoggers();

            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        } 
        #endregion
    }
}
