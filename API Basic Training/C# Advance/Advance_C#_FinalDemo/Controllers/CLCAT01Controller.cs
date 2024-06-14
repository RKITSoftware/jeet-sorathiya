using Advance_C__FinalDemo.Attribute;
using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling category-related actions.
    /// </summary>
    [RoutePrefix("api/Category")]
    public class CLCAT01Controller : ApiController
    {
        #region Private Fields
        private BLCAT01 _objBLCategory;
        #endregion
        #region Public Fields
        public Response _objResponse;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CLCAT01Controller"/> class.
        /// </summary>
        public CLCAT01Controller()
        {
            _objBLCategory = new BLCAT01();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>An HTTP response with a list of all categories.</returns>
        [HttpGet]
        [Route("Category")]
        public IHttpActionResult GetAllCategory()
        {
            return Ok(_objBLCategory.GetAll());
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="newCategory">The new category to be added.</param>
        /// <returns>An HTTP response indicating the result of the add operation.</returns>
        [HttpPost]
        [Route("AddNewCategory")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
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

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="newCategory">The category to be updated.</param>
        /// <returns>An HTTP response indicating the result of the update operation.</returns>
        [HttpPut]
        [Route("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public IHttpActionResult UpdateCategory(DTOCAT01 newCategory)
        {
            _objBLCategory.Type = EnmType.E;
            _objBLCategory.PreSave(newCategory);
            _objResponse = _objBLCategory.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLCategory.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        /// <param name="id">The ID of the category to be deleted.</param>
        /// <returns>An HTTP response indicating the result of the delete operation.</returns>
        [HttpDelete]
        [Route("DeleteCategory")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteCategory(int id)
        {
            return Ok(_objBLCategory.Delete(id));
        } 
        #endregion
    }
}
