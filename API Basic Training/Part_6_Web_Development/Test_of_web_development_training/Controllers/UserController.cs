using System.Web.Http;
using Test_of_web_development_training.Models;
using Test_of_web_development_training.SEC__Security;

namespace Test_of_web_development_training.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [BasicAuthentication]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        [HttpGet]
        [Route("AllUserList")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult AllUserList()
        {
            var userList = Models.User.GetUserList();
            return Ok(userList);
        }

        /// <summary>
        /// Retrieves information about a specific user by ID.
        /// </summary>
        [HttpGet]
        [Route("UserInfo/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult UserInfo(int id)
        {
            return Ok(Models.User.GetUserList().Find(usr => usr.Id == id));
        }

        /// <summary>
        /// Updates details of a specific user by ID.
        /// </summary>
        [HttpPut]
        [Route("UpdateUserDetails/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult UpdateUserDetails(int id, [FromBody] User newUser)
        {
            User objofUser = new User();
            objofUser.Update(id, newUser);

            return Ok();
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        [HttpPost]
        [Route("AddNewUser")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult AddNewUser(User newUser)
        {
            Models.User.AddNew(newUser);
            return Ok();
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        [BasicAuthorization(Roles = "Admin")]
        public IHttpActionResult DeleteUser(int id)
        {
            User objofUser = new User();
            objofUser.Delete(id);
            return Ok();
        }

    }
}
