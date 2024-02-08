using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// Custom exception filter attribute for logging exceptions and providing a generic response.
    /// </summary>
    public class LoggingExceptionFilterAttribute : ExceptionFilterAttribute
    {
        // Ensure thread-safe logging using a lock object
        private static readonly object LockObject = new object();

        /// <summary>
        /// Handles exceptions and logs details to a file.
        /// </summary>
        /// <param name="context">The context containing information about the exception.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // Generate a unique ID for the exception
            string uniqueId = Guid.NewGuid().ToString();

            // Log exception details to file
            LogExceptionToFile(uniqueId, context.Exception);

            // Customize the response based on your requirements
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent($"Internal server error occurred. Exception Id: {uniqueId}"),
                ReasonPhrase = "Internal Server Error"
            };

        }

        /// <summary>
        /// Logs exception details to a file.
        /// </summary>
        /// <param name="uniqueId">The unique identifier for the exception.</param>
        /// <param name="exception">The exception to be logged.</param>
        private void LogExceptionToFile(string uniqueId, Exception exception)
        {
            lock (LockObject)
            {
                // Specify the log directory path
                string logDirectoryPath = HttpContext.Current.Server.MapPath("~/Logs");

                // Check if the log directory exists; if not, create it
                if (!Directory.Exists(logDirectoryPath))
                {
                    Directory.CreateDirectory(logDirectoryPath);
                    File.Create(Path.Combine(logDirectoryPath, "Log.txt"));
                }

                // Specify the log file path
                string logFilePath = Path.Combine(logDirectoryPath, "Log.txt");

                // Write exception details to the log file
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"Exception Id: {uniqueId}");
                    writer.WriteLine($"Timestamp: {DateTime.Now}");
                    writer.WriteLine($"Exception Type: {exception.GetType().FullName}");
                    writer.WriteLine($"Exception Message: {exception.Message}");
                    writer.WriteLine($"Stack Trace: {exception.StackTrace}");
                    writer.WriteLine();
                }
            }

        }
    }
}