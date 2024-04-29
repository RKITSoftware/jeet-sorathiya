using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// API Controller for managing movie-related operations
    /// </summary>
    [RoutePrefix("api/Movies")]
    public class CLMoviesController : ApiController
    {
        private BLMovies _objBLMovies;
        public Response _objResponse;

        /// <summary>
        /// Initializes a new instance of the CLMoviesController class.
        /// </summary>
        public CLMoviesController()
        {
            _objBLMovies = new BLMovies();
        }

        /// <summary>
        /// Retrieves all movies from the database.
        /// </summary>
        /// <returns>An HttpResponseMessage containing JSON of movies.</returns>
        [HttpGet]
        [Route("Movies")]
        public HttpResponseMessage Movies()
        {
            return _objBLMovies.GetAll();
        }

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="newMovie">The DTOMOV01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        [HttpPost]
        [Route("AddMovie")]
        public Response AddNewMovie(DTOMOV01 newMovie)
        {
            _objBLMovies.Type = EnmType.A;
            _objBLMovies.PreSave(null, newMovie);
            _objResponse = _objBLMovies.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLMovies.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing movie in the database.
        /// </summary>
        /// <param name="newMovie">The DTOMOV01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        [HttpPut]
        [Route("UpdateMovie")]
        public Response UpdateMovie(DTOMOV01 newMovie)
        {
            _objBLMovies.Type = EnmType.E;
            _objBLMovies.PreSave(null, newMovie);
            _objResponse = _objBLMovies.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLMovies.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="id">The ID of the movie </param>
        /// <returns>An HttpResponseMessage indicating the outcome of the deletion operation.</returns>
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage DeleteMovie(int id)
        {
            if (id > 0)
            {
                // If the movie is successfully deleted, return HTTP OK status
                if (_objBLMovies.Delete(id))
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    // If there is an internal server error during movie deletion, return HTTP InternalServerError status
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                // If the provided movie ID is not valid, return HTTP BadRequest status
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
