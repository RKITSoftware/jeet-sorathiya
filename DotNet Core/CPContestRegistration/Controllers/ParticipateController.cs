using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    /// <summary>
    /// Controller for managing participation-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipateController : ControllerBase
    {
        private readonly IParticipateManagement _participateManagement;

        /// <summary>
        /// Constructor for ParticipateController.
        /// </summary>
        /// <param name="participateManagement">Participation management service instance.</param>
        public ParticipateController(IParticipateManagement participateManagement)
        {
            _participateManagement = participateManagement;
        }

        /// <summary>
        /// Adds a new participation 
        /// </summary>
        /// <param name="objPAR01">The participation to add.</param>
        /// <returns>An ActionResult representing the operation result.</returns>
        [HttpPost("AddParticipate")]
        public ActionResult AddParticipate(PAR01 objPAR01)
        {
            if (objPAR01 != null)
            {
                if (_participateManagement.Add(objPAR01))
                {
                    return Ok($"{objPAR01.R01F02} is Added");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        /// <summary>
        /// Updates an existing participation 
        /// </summary>
        /// <param name="objPAR01">The participation  to update.</param>
        /// <returns>An ActionResult representing the operation result.</returns>
        [HttpPut("UpdateParticipate")]
        public ActionResult UpdateParticipate(PAR01 objPAR01)
        {
            if (objPAR01 != null)
            {
                if (_participateManagement.Update(objPAR01))
                {
                    return Ok($"{objPAR01.R01F02} is Updated");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        /// <summary>
        /// Deletes a participation 
        /// </summary>
        /// <param name="id">The ID of the participation to delete.</param>
        /// <returns>An ActionResult representing the operation result.</returns>
        [HttpDelete("DeleteParticipate/{id}")]
        public ActionResult DeleteParticipate(int id)
        {
            if (id > 0)
            {
                if (_participateManagement.Delete(id))
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();

        }

        /// <summary>
        /// Retrieves all participation
        /// </summary>
        /// <returns>An ActionResult containing the participation</returns>
        [HttpGet("Participate")]
        public ActionResult Participate()
        {
            return Ok(_participateManagement.SelectAll().ToJson());
        }

        /// <summary>
        /// Retrieves a participation by its ID.
        /// </summary>
        /// <param name="id">The ID of the participation to retrieve.</param>
        /// <returns>An ActionResult containing the participation</returns>
        [HttpGet("Participate/{id}")]
        public ActionResult ParticipatebyID(int id)
        {
            if (id > 0)
            {
                return Ok(_participateManagement.SelectPk(id));
            }
            return BadRequest();
        }
    }
}
