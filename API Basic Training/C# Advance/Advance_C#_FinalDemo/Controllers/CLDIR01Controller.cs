using Advance_C__FinalDemo.Attribute;
using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling director-related actions.
    /// </summary>
    [RoutePrefix("api/Director")]
    public class CLDIR01Controller : ApiController
    {
        #region Private Fields
        private BLDIR01 _objBLDirector;
        #endregion
        #region public Fields
        public Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CLDIR01Controller"/> class.
        /// </summary>
        public CLDIR01Controller()
        {
            _objBLDirector = new BLDIR01();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all directors.
        /// </summary>
        /// <returns>An HTTP response with a list of all directors.</returns>
        [HttpGet]
        [Route("Director")]
        public IHttpActionResult GetAllDirectors()
        {
            return Ok(_objBLDirector.GetAll());
        }

        /// <summary>
        /// Adds a new director.
        /// </summary>
        /// <param name="newDirector">The new director to be added.</param>
        /// <returns>An HTTP response indicating the result of the add operation.</returns>
        [HttpPost]
        [Route("AddNewDirector")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public IHttpActionResult AddDirector(DTODIR01 newDirector)
        {
            _objBLDirector.Type = EnmType.A;
            _objBLDirector.PreSave(newDirector);
            _objResponse = _objBLDirector.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLDirector.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing director.
        /// </summary>
        /// <param name="newDirector">The director to be updated.</param>
        /// <returns>An HTTP response indicating the result of the update operation.</returns>
        [HttpPut]
        [Route("UpdateDirector")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public IHttpActionResult UpdateDirector(DTODIR01 newDirector)
        {
            _objBLDirector.Type = EnmType.E;
            _objBLDirector.PreSave(newDirector);
            _objResponse = _objBLDirector.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLDirector.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a director.
        /// </summary>
        /// <param name="id">The ID of the director to be deleted.</param>
        /// <returns>An HTTP response indicating the result of the delete operation.</returns>
        [HttpDelete]
        [Route("DeleteDirector")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteDirector(int id)
        {
            return Ok(_objBLDirector.Delete(id));
        } 
        #endregion
    }
}
