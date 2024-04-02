using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipateController : ControllerBase
    {
        private readonly IParticipateManagement _participateManagement;

        public ParticipateController(IParticipateManagement participateManagement)
        {
            _participateManagement = participateManagement;
        }

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

        [HttpGet("Participate")]
        public ActionResult Participate()
        {
            return Ok(_participateManagement.SelectAll());
        }

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
