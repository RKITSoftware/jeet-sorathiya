using System.Web.Http;
using Test_of_web_development_training.BL;
using Test_of_web_development_training.Models;
using Test_of_web_development_training.Models.DTO;
using Test_of_web_development_training.Models.Enum;
using Test_of_web_development_training.SEC__Security;

namespace Test_of_web_development_training.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [BasicAuthentication]
    [RoutePrefix("api/User")]
    public class CLUserController : ApiController
    {
        private readonly BLUserManager _blUserManager;
        private Response _objResponse;

        /// <summary>
        /// Constructor to initialize the UserManager.
        /// </summary>
        public CLUserController()
        {
            _blUserManager = new BLUserManager();
        }

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>The list of all users.</returns>
        [HttpGet]
        [Route("AllUserList")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult AllUserList()
        {
            var userList = _blUserManager.GetAllUsers();
            return Ok(userList);
        }

        /// <summary>
        /// Retrieves information about a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns>The user information if found; otherwise, NotFound.</returns>
        [HttpGet]
        [Route("UserInfo/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult UserInfo(int id) // bl??
        {
            var user = _blUserManager.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Updates details of a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="newUser">The updated details of the user.</param>
        /// <returns>The response indicating the success or failure of the operation.</returns>
        [HttpPut]
        [Route("UpdateUserDetails/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public Response UpdateUserDetails(int id, [FromBody] DTOUser newUser) // return ok ??
        {

            _blUserManager.Type = EnmType.E;
            _blUserManager.PreSave(id, newUser);
            _objResponse = _blUserManager.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _blUserManager.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="newUser">The details of the new user to add.</param>
        /// <returns>The response indicating the success or failure of the operation.</returns>
        [HttpPost]
        [Route("AddNewUser")]
        [BasicAuthorization(Roles = "Admin")]
        public Response AddNewUser(DTOUser newUser)
        {
            _blUserManager.Type = EnmType.A;
            _blUserManager.PreSave(null, newUser);
            _objResponse = _blUserManager.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _blUserManager.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>The response indicating the success or failure of the operation.</returns>
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult DeleteUser(int id)
        {
            _blUserManager.Delete(id);
            return Ok();
        }

    }
}
