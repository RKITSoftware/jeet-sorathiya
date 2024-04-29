using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace HTTPcaching
{
 
    public class BLCacheManager
    {
        private static string _etag = Guid.NewGuid().ToString();
        private static object _cachedData;

      
        public HttpResponseMessage GetCachedResponse(HttpRequestMessage request, Func<object> fetchData)
        {
            var requestETag = request.Headers.IfNoneMatch.FirstOrDefault();

            if (IsCachedDataValid(requestETag))
            {
                return request.CreateResponse(HttpStatusCode.NotModified);
            }

            object data = fetchData();

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, data);
            response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + _etag + "\"");
            response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(5), // Cache for 5 minutes
                Public = true
            };

            _cachedData = data;

            return response;
        }

        private bool IsCachedDataValid(System.Net.Http.Headers.EntityTagHeaderValue requestETag)
        {
            return requestETag != null && requestETag.Tag == "\"" + _etag + "\"";
        }
    }

}