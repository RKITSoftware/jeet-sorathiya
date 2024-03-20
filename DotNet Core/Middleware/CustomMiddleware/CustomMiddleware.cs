namespace Middleware.CustomMiddleware
{
    /// <summary>
    /// CustomMiddleware for log info about request
    /// </summary>
    public class CustomMiddleware : IMiddleware
    {
        /// <summary>
        /// asyc type InvokeAsync method for log info about request
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"Request Path : {context.Request.Path}");

            Console.WriteLine($"Method Type : {context.Request.Method}");

            await next(context); // call next middleware

            Console.WriteLine($"Response Code : {context.Response.StatusCode}");
        }
    }
}
