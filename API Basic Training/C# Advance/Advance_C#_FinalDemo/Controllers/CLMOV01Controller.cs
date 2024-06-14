using Advance_C__FinalDemo.Attribute;
using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using System.Net.Http;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling movie-related actions.
    /// </summary>
    [RoutePrefix("api/Movies")]
    public class CLMOV01Controller : ApiController
    {
        #region Private Fields
        private BLMOV01 _objBLMovies;
        #endregion
        #region Public Fields
        public Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CLMOV01Controller"/> class.
        /// </summary>
        public CLMOV01Controller()
        {
            _objBLMovies = new BLMOV01();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        /// <returns>An HTTP response with a list of all movies.</returns>
        [HttpGet]
        [Route("Movies")]
        public HttpResponseMessage Movies()
        {
            return _objBLMovies.GetAll();
        }

        /// <summary>
        /// Adds a new movie.
        /// </summary>
        /// <param name="newMovie">The new movie to be added.</param>
        /// <returns>An HTTP response indicating the result of the add operation.</returns>
        [HttpPost]
        [Route("AddMovie")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public Response AddNewMovie(DTOMOV01 newMovie)
        {
            _objBLMovies.Type = EnmType.A;
            _objBLMovies.PreSave(newMovie);
            _objResponse = _objBLMovies.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLMovies.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing movie.
        /// </summary>
        /// <param name="newMovie">The movie to be updated.</param>
        /// <returns>An HTTP response indicating the result of the update operation.</returns>
        [HttpPut]
        [Route("UpdateMovie")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public Response UpdateMovie(DTOMOV01 newMovie)
        {
            _objBLMovies.Type = EnmType.E;
            _objBLMovies.PreSave(newMovie);
            _objResponse = _objBLMovies.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLMovies.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a movie.
        /// </summary>
        /// <param name="id">The ID of the movie to be deleted.</param>
        /// <returns>An HTTP response indicating the result of the delete operation.</returns>
        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteMovie(int id)
        {
            return Ok(_objBLMovies.Delete(id));
        } 
        #endregion
    }
}
