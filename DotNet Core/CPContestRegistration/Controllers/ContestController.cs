using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    /// <summary>
    /// Controller for managing contest-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private readonly IContestManagement _contestManagement;

        /// <summary>
        /// Constructor for ContestController.
        /// </summary>
        /// <param name="contestManagement">Contest management service instance.</param>

        public ContestController(IContestManagement contestManagement)
        {
            _contestManagement = contestManagement;
        }

        /// <summary>
        /// Adds a new contest.
        /// </summary>
        [HttpPost("AddContest")]
        public ActionResult AddContest(CON01 objCON01)
        {
            if (objCON01 != null)
            {
                if (_contestManagement.Add(objCON01))
                {
                    return StatusCode(201, $"{objCON01.N01F02} is Added");
                }

            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Updates an existing contest.
        /// </summary>
        [HttpPut("UpdateContest")]
        public ActionResult UpdateContest(CON01 objCON01)
        {
            if (objCON01 != null)
            {
                if (_contestManagement.Update(objCON01))
                {
                    return Ok($"{objCON01.N01F02} is Updated");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Deletes a contest.
        /// </summary>
        [HttpDelete("DeleteContest/{id}")]
        public ActionResult DeleteContest(int id)
        {
            if (id > 0)
            {
                if (_contestManagement.Delete(id))
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Retrieves all contests.
        /// </summary>
        [HttpGet("Contest")]
        [AllowAnonymous]
        public ActionResult Contest()
        {
            return Ok(_contestManagement.SelectAll().ToJson());
        }

        /// <summary>
        /// Retrieves a contest by its ID.
        /// </summary>
        [HttpGet("Contest/{id}")]
        [AllowAnonymous]
        public ActionResult ContestByID(int id)
        {
            if (id > 0)
            {
                return Ok(_contestManagement.SelectPk(id));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
