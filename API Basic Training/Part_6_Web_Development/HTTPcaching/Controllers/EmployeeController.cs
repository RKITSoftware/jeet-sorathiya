using HTTPcaching.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace HTTPcaching.Controllers
{

    public class EmployeeController : ApiController
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Jeet"},
            new Employee { Id = 2, Name = "Tony Stark" },
            new Employee { Id = 3, Name = "Spider-Man" },
            new Employee { Id = 4, Name = "Hulk" },
            new Employee { Id = 5, Name = "Thor" },
            new Employee { Id = 6, Name = "Black Widow" },
            new Employee { Id = 7, Name = "Captain America" },
            new Employee { Id = 8, Name = "Doctor Strange" },
            new Employee { Id = 9, Name = "Black Panther" },
            new Employee { Id = 10, Name = "Captain Marvel" }
        };

        private static CacheManager cacheManager = new CacheManager();

        /// <summary>
        /// Retrieves a list of employees with HTTP caching support.
        /// </summary>
        /// <returns>An HTTP response message containing the list of employees.</returns>
        public HttpResponseMessage Get()
        {
            return cacheManager.GetCachedResponse(Request, FetchData);
        }

        /// <summary>
        /// Fetches the employee data to be cached.
        /// </summary>
        /// <returns>The list of employees.</returns>
        private object FetchData()
        {
            return employees;
        }
    }
}
