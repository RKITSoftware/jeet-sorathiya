using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;

        /// <summary>
        /// Constructor for UserController.
        /// </summary>
        /// <param name="userManagement">User management service instance.</param>
        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="objUSE01">The user to add.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpPost("AddUser")]
        public ActionResult AddUser(USE01 objUSE01)
        {
            if (objUSE01 != null)
            {
                if (_userManagement.Add(objUSE01))
                {
                    return Ok($"{objUSE01.E01F02} is Added");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="objUSE01">The user to update.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpPut("UpdateUser")]
        public ActionResult UpdateUser(USE01 objUSE01)
        {
            if (objUSE01 != null)
            {
                if (_userManagement.Update(objUSE01))
                {
                    return Ok($"{objUSE01.E01F02} is Updated");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        /// <summary>
        /// Deletes a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpDelete("DeleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (id > 0)
            {
                if (_userManagement.Delete(id))
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An ActionResult containing the list of users.</returns>
        [HttpGet("Users")]
        public ActionResult Users()
        {
            return Ok(_userManagement.SelectAll().ToJson());
        }

        /// <summary>
        /// Retrieves a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An ActionResult containing the user.</returns>
        [HttpGet("Users/{id}")]
        public ActionResult UserByID(int id)
        {
            if (id > 0)
            {
                return Ok(_userManagement.SelectPk(id));
            }
            return BadRequest();
        }
    }
}
