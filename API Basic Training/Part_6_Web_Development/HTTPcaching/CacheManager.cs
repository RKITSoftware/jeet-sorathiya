using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace HTTPcaching
{
    /// <summary>
    /// Manages HTTP caching for a specified data type.
    /// </summary>
    public class CacheManager
    {
        private static string etag = Guid.NewGuid().ToString();
        private static object cachedData;

        /// <summary>
        /// Gets a cached HTTP response or fetches new data if the cache is stale.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="fetchData">A function to fetch new data if the cache is stale.</param>
        /// <returns>An HTTP response message with appropriate caching headers.</returns>
        public HttpResponseMessage GetCachedResponse(HttpRequestMessage request, Func<object> fetchData)
        {
            var requestETag = request.Headers.IfNoneMatch.FirstOrDefault();

            if (IsCachedDataValid(requestETag))
            {
                return request.CreateResponse(HttpStatusCode.NotModified);
            }

            object data = fetchData();

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, data);
            response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + etag + "\"");
            response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(5), // Cache for 5 minutes
                Public = true
            };

            cachedData = data;

            return response;
        }

        private bool IsCachedDataValid(System.Net.Http.Headers.EntityTagHeaderValue requestETag)
        {
            return requestETag != null && requestETag.Tag == "\"" + etag + "\"";
        }
    }

}