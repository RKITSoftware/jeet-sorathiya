using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Advance_C__FinalDemo.Models.POCO;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// API Controller for managing category-related operations
    /// </summary>
    [RoutePrefix("api/Category")]
    public class CLCategoryController : ApiController
    {
        private BLCategory _objBLCategory;
        public Response _objResponse;

        /// <summary>
        /// Initializes a new instance of the CLCategoryController class.
        /// </summary>
        public CLCategoryController()
        {
            _objBLCategory = new BLCategory();
        }


        [HttpGet]
        [Route("Category")]
        public IHttpActionResult GetAllCategory()
        {
            return Ok(_objBLCategory.GetAll());
        }


        [HttpPost]
        [Route("AddNewCategory")]
        public IHttpActionResult AddCategory(DTOCAT01 newCategory)
        {
            _objBLCategory.Type = EnmType.A;
            _objBLCategory.PreSave(newCategory);
            _objResponse = _objBLCategory.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLCategory.Save();
            }
            return Ok(_objResponse);
        }


        [HttpPut]
        [Route("UpdateCategory")]
        public IHttpActionResult UpdateCategory(int id, DTOCAT01 newCategory)
        {
            _objBLCategory.Type = EnmType.E;
            _objBLCategory.PreSave(newCategory,id);
            _objResponse = _objBLCategory.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLCategory.Save();
            }
            return Ok(_objResponse);
        }


        [HttpDelete]
        [Route("DeleteCategory")]
        public IHttpActionResult DeleteCategory(int id)
        {
            return Ok(_objBLCategory.Delete(id));
        }

    }
}
