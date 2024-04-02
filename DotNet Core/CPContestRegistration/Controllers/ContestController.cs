using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private readonly IContestManagement _contestManagement;

        public ContestController(IContestManagement contestManagement)
        {
            _contestManagement = contestManagement;
        }

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

        [HttpGet("Contest")]
        public ActionResult Contest()
        {
            return Ok(_contestManagement.SelectAll().ToJson());
        }

        [HttpGet("Contest/{id}")]
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
