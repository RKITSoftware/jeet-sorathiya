using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace CORS.Controllers
{
    /// <summary>
    /// Controller for handling CORS-related requests.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CLCorsController : ApiController
    {
        // Data to be returned by the API
        public List<string> data = new List<string> { "Jeet", "Tony-Stark", "Captain-America", "SpiderMan" };

        /// <summary>
        /// Gets the entire list of data.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            // Return the entire list of data
            return Ok(data);
        }

        /// <summary>
        /// Gets a specific item from the data list based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the item to retrieve.</param>
        [HttpGet]
        [DisableCors] // Disabling CORS for this specific action
        public IHttpActionResult Get(int id)
        {
            if (id < 1 && id > data.Count)
            {
                return NotFound();
            }
            return Ok(data[id - 1]);
        }
    }
}
