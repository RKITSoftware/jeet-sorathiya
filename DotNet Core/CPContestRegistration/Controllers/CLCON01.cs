using CPContestRegistration.BL.Interface;
using CPContestRegistration.Filters;
using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    /// <summary>
    /// Controller for managing contest-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLCON01 : ControllerBase
    {
        #region Private Fields
        private readonly ICON01 _contestManagement;
        private Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for ContestController.
        /// </summary>
        /// <param name="contestManagement">Contest management service instance.</param>

        public CLCON01(ICON01 contestManagement)
        {
            _contestManagement = contestManagement;
            _objResponse = new Response();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add new Contest
        /// </summary>
        /// <param name="objCON01">DTO model of contest</param>
        /// <returns>response object</returns>
        [HttpPost("AddContest")]
        [MyAuthorize(Roles = "Admin")]
        public IActionResult AddContest(DTOCON01 objCON01)
        {
            _contestManagement.Operation = EnmOperation.A;
            _contestManagement.PreSave(objCON01);
            _objResponse = _contestManagement.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _contestManagement.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Update Contest
        /// </summary>
        /// <param name="objCON01">DTO model of contest</param>
        /// <returns>response object</returns>
        [HttpPut("UpdateContest")]
        [MyAuthorize(Roles = "Admin")]

        public IActionResult UpdateContest(DTOCON01 objCON01)
        {
            _contestManagement.Operation = EnmOperation.E;
            _contestManagement.PreSave(objCON01);
            _objResponse = _contestManagement.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _contestManagement.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Delete Contest
        /// </summary>
        /// <param name="id">id of contest</param>
        /// <returns>response object</returns>
        [HttpDelete("DeleteContest/{id}")]
        [MyAuthorize(Roles = "Admin")]
        public IActionResult DeleteContest(int id)
        {
            return Ok(_contestManagement.Delete(id));
        }

        /// <summary>
        /// Retrieves all contest entries.
        /// </summary>
        /// <returns>An IActionResult containing a response with all contest</returns>
        [HttpGet("Contest")]
        [AllowAnonymous]
        public IActionResult Contest()
        {
            return Ok(_contestManagement.SelectAll());
        }

        /// <summary>
        /// Retrieves a contest entry by its id.
        /// </summary>
        /// <param name="id">The id of the contest </param>
        /// <returns>An ActionResult containing a response with the contest entry specified by the id.</returns>
        [HttpGet("ContestByID/{id}")]
        [AllowAnonymous]
        public ActionResult ContestByID(int id)
        {
            return Ok(_contestManagement.SelectPk(id));
        } 
        #endregion
    }
}
