using Advance_C__FinalDemo.Attribute;
using Advance_C__FinalDemo.BL.Service;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// Controller for managing user-related actions.
    /// </summary>
    [RoutePrefix("api/Users")]
    [Authorize(Roles = "Admin")]
    public class CLUSR01Controller : ApiController
    {
        #region Private Fields
        private BLUSR01 _objBLUser;
        #endregion
        #region Public Fields
        public Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CLUSR01Controller"/> class.
        /// </summary>
        public CLUSR01Controller()
        {
            _objBLUser = new BLUSR01();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An HTTP response with a list of all users.</returns>
        [HttpGet]
        [Route("Users")]
        public IHttpActionResult Movies()
        {
            return Ok(_objBLUser.GetData());
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="newUser">The new user to be added.</param>
        /// <returns>An HTTP response indicating the result of the add operation.</returns>
        [HttpPost]
        [Route("AddUser")]
        [ValidateModel]
        public Response AddNewUser(DTOUSR01 newUser)
        {
            _objBLUser.Type = EnmType.A;
            _objBLUser.PreSave(newUser);
            _objResponse = _objBLUser.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLUser.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="newUser">The user to be updated.</param>
        /// <returns>An HTTP response indicating the result of the update operation.</returns>
        [HttpPut]
        [Route("UpdateUser")]
        [ValidateModel]
        public Response UpdateUser(DTOUSR01 newUser)
        {
            _objBLUser.Type = EnmType.E;
            _objBLUser.PreSave(newUser);
            _objResponse = _objBLUser.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLUser.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        /// <returns>An HTTP response indicating the result of the delete operation.</returns>
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(_objBLUser.Delete(id));
        } 
        #endregion
    }
}
