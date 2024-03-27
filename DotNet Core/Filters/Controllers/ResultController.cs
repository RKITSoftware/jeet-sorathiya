using Filters.Filter;
using Filters.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HandleExceptionFilter]
    [CustomResultFilter]
    [ActionInfoFilter]
    /// <summary>
    /// Controller for managing results.
    /// </summary>
    public class ResultController : ControllerBase
    {
        // dummy results
        public static List<Result> results = new List<Result>
        {
            new Result{ RollNumber = 101, Name = "Student-1", Spi = 8, Cpi = 7.5, Cgpa = 7.3 },
            new Result{ RollNumber = 102, Name = "Student-2", Spi = 8.2, Cpi = 9.2, Cgpa = 8.5}
        };

        /// <summary>
        /// Get all results.
        /// </summary>
        /// <returns>List of results.</returns>
        [ApiKeyAuthorizationFilter("jeet")]
        [HttpGet("GetAllResults")]
        public ActionResult Get()
        {
            return Ok(results);
        }

        /// <summary>
        /// Get old results (throws an exception for demonstration).
        /// </summary>
        /// <returns>Error response.</returns>
        [HttpGet("OldResults")]
        public ActionResult OldResults()
        {
            throw new Exception();
        }
    }
}
