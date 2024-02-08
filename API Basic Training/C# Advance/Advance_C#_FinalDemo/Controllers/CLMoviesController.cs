using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
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
        private BLMovies _bLMovies;

        /// <summary>
        /// Gets a list of all movies
        /// </summary>
        [HttpGet]
        [Route("Movies")]
        public HttpResponseMessage Movies()
        {
            _bLMovies = new BLMovies();
            return _bLMovies.GetAll();
        }

        /// <summary>
        /// Adds a new movie
        /// </summary>
        [HttpPost]
        [Route("AddMovie")]
        public HttpResponseMessage AddNewMovie(MOV01 newMovie)
        {
            _bLMovies = new BLMovies();
            if (newMovie != null)
            {
                // If the movie is successfully added, return HTTP Created status
                if (_bLMovies.Add(newMovie))
                {
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    // If there is an internal server error during movie addition, return HTTP InternalServerError status
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            // If the provided movie is null, return HTTP BadRequest status
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Updates an existing movie
        /// </summary>
        [HttpPut]
        [Route("UpdateMovie")]
        public HttpResponseMessage UpdateMovie(MOV01 newMovie)
        {
            _bLMovies = new BLMovies();
            if (newMovie != null)
            {
                // If the movie is successfully updated, return HTTP OK status
                if (_bLMovies.Update(newMovie))
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    // If there is an internal server error during movie update, return HTTP InternalServerError status
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                // If the provided movie is null, return HTTP BadRequest status
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Deletes a movie by its ID
        /// </summary>
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage DeleteMovie(int id)
        {
            _bLMovies = new BLMovies();
            if (id > 0)
            {
                // If the movie is successfully deleted, return HTTP OK status
                if (_bLMovies.Delete(id))
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
