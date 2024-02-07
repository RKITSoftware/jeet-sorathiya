using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http.Filters;

namespace Advance_C__FinalDemo.BL
{
    public class LoggingExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly object LockObject = new object();
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
        private void LogExceptionToFile(string uniqueId, Exception exception)
        {
            lock (LockObject)
            {
                string logDirectoryPath = HttpContext.Current.Server.MapPath("~/Logs");
                if (!Directory.Exists(logDirectoryPath))
                {
                    Directory.CreateDirectory(logDirectoryPath);
                    File.Create(Path.Combine(logDirectoryPath, "Log.txt"));
                }
                string logFilePath = Path.Combine(logDirectoryPath, "Log.txt");

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