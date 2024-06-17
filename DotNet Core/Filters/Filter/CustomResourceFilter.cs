using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Text.Json;

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

    /// <summary>
    /// Custom Resource filter for cache response
    /// </summary>
    public class ResourceCatchFilter : Attribute, IAsyncResourceFilter
    {
        #region Private Fields
        private readonly IMemoryCache _cache;
        #endregion

        #region Constructor
        public ResourceCatchFilter(IMemoryCache cache)
        {
            _cache = cache;
        }
        #endregion

        #region Public Methods
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var url = context.HttpContext.Request.Path.Value;

            if (_cache.TryGetValue(url, out string value))
            {
                context.Result = new ContentResult
                {
                    Content = value,
                    StatusCode = 200,
                    ContentType = "application/json"
                };
            }
            else
            {
                var executedContext = await next();
                if (executedContext.Result is ObjectResult result && result.StatusCode == StatusCodes.Status200OK)
                {
                    var resultData = JsonSerializer.Serialize(result.Value);
                    _cache.Set(url, resultData, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10000)
                    });
                }
            }
        }
        #endregion
    }
}
