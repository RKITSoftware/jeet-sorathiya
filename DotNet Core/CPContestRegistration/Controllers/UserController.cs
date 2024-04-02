using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;

        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

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

        [HttpGet("Users")]
        public ActionResult Users()
        {
            return Ok(_userManagement.SelectAll());
        }

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
