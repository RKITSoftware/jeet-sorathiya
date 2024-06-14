using CPContestRegistration.BL.Interface;
using CPContestRegistration.Filters;
using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CPContestRegistration.Controllers
{
    /// <summary>
    /// Controller for managing participation-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLPAR01 : ControllerBase
    {
        #region Private Fields
        private readonly IPAR01 _participateManagement;
        private Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for ParticipateController.
        /// </summary>
        /// <param name="participateManagement">Participation management service instance.</param>
        public CLPAR01(IPAR01 participateManagement)
        {
            _participateManagement = participateManagement;
            _objResponse = new Response();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new participation 
        /// </summary>
        /// <param name="objPAR01">The participation to add.</param>
        /// <returns>An ActionResult representing the operation result.</returns>
        [HttpPost("AddParticipate")]
        public IActionResult AddParticipate(DTOPAR01 objPAR01)
        {
            _participateManagement.Operation = EnmOperation.A;
            _participateManagement.PreSave(objPAR01);
            _objResponse = _participateManagement.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _participateManagement.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing participation 
        /// </summary>
        /// <param name="objPAR01">The participation  to update.</param>
        /// <returns>An ActionResult representing the operation result.</returns>
        [HttpPut("UpdateParticipate")]
        public IActionResult UpdateParticipate(DTOPAR01 objPAR01)
        {
            _participateManagement.Operation = EnmOperation.E;
            _participateManagement.PreSave(objPAR01);
            _objResponse = _participateManagement.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _participateManagement.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a participation 
        /// </summary>
        /// <param name="id">The ID of the participation to delete.</param>
        /// <returns>An ActionResult representing the operation result.</returns>
        [HttpDelete("DeleteParticipate/{id}")]
        public IActionResult DeleteParticipate(int id)
        {
            return Ok(_participateManagement.Delete(id));
        }

        /// <summary>
        /// Retrieves all participation
        /// </summary>
        /// <returns>An ActionResult containing the participation</returns>
        [HttpGet("Participate")]
        [MyAuthorize(Roles = "Admin")]
        public IActionResult Participate()
        {
            return Ok(_participateManagement.SelectAll());
        }

        /// <summary>
        /// Retrieves a participation by its ID.
        /// </summary>
        /// <param name="id">The ID of the participation to retrieve.</param>
        /// <returns>An ActionResult containing the participation</returns>
        [HttpGet("Participate/{id}")]
        public IActionResult ParticipatebyID(int id)
        {
            return Ok(_participateManagement.SelectPk(id));
        }
        #endregion
    }
}
