using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// API Controller for managing director-related operations
    /// </summary>
    [RoutePrefix("api/Director")]
    public class CLDirectorController : ApiController
    {
        private BLDirector _objBLDirector;
        public Response _objResponse;

        /// <summary>
        /// Initializes a new instance of the CLDirectorController class.
        /// </summary>
        public CLDirectorController()
        {
            _objBLDirector = new BLDirector();
        }


        [HttpGet]
        [Route("Director")]
        public IHttpActionResult GetAllCategory()
        {
            return Ok(_objBLDirector.GetAll());
        }


        [HttpPost]
        [Route("AddNewDirector")]
        public IHttpActionResult AddDirector(DTODIR01 newDirector)
        {
            _objBLDirector.Type = EnmType.A;
            _objBLDirector.PreSave(newDirector);
            _objResponse = _objBLDirector.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLDirector.Save();
            }
            return Ok(_objResponse);

        }

        [HttpPut]
        [Route("UpdateDirector")]
        public IHttpActionResult UpdateCategory(int id, DTODIR01 newDirector)
        {
            _objBLDirector.Type = EnmType.A;
            _objBLDirector.PreSave(newDirector,id);
            _objResponse = _objBLDirector.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLDirector.Save();
            }
            return Ok(_objResponse);
        }

        [HttpDelete]
        [Route("DeleteDirector")]
        public IHttpActionResult DeleteDirector(int id)
        {
            return Ok(_objBLDirector.Delete(id));
        }
    }
}
