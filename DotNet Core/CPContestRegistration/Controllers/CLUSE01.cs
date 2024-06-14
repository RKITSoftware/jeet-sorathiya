using CPContestRegistration.BL.Interface;
using CPContestRegistration.Filters;
using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class CLUSE01 : ControllerBase
    {
        #region Private Fields
        private readonly IUSE01 _userManagement;
        private Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for UserController.
        /// </summary>
        /// <param name="userManagement">User management service instance.</param>
        public CLUSE01(IUSE01 userManagement)
        {
            _userManagement = userManagement;
            _objResponse = new Response();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="objUSE01">The user to add.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpPost("AddUser")]
        [MyAuthorize(Roles = "Admin")]
        public IActionResult AddUser(DTOUSE01 objUSE01)
        {
            _userManagement.Operation = EnmOperation.A;
            _userManagement.PreSave(objUSE01);
            _objResponse = _userManagement.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _userManagement.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="objUSE01">The user to update.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpPut("UpdateUser")]
        [MyAuthorize(Roles = "Admin")]
        public IActionResult UpdateUser(DTOUSE01 objUSE01)
        {
            _userManagement.Operation = EnmOperation.E;
            _userManagement.PreSave(objUSE01);
            _objResponse = _userManagement.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _userManagement.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpDelete("DeleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            return Ok(_userManagement.Delete(id));
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An ActionResult containing the list of users.</returns>
        [HttpGet("Users")]
        [MyAuthorize(Roles = "Admin")]
        public ActionResult Users()
        {
            return Ok(_userManagement.SelectAll());
        }

        /// <summary>
        /// Retrieves a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An ActionResult containing the user.</returns>
        [HttpGet("Users/{id}")]
        public ActionResult UserByID(int id)
        {
            return Ok(_userManagement.SelectPk(id));
        }
        #endregion
    }
}
