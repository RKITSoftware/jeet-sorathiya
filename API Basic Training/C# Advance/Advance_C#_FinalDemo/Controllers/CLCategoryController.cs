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

        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>An HttpResponseMessage containing JSON type categories.</returns>
        [HttpGet]
        [Route("Category")]
        public HttpResponseMessage GetAllCategory()
        {
            DataTable dataTableOfCategory = _objBLCategory.GetAll();

            // Serialize the DataTable to JSON using Json.NET
            string jsonData = JsonConvert.SerializeObject(dataTableOfCategory);

            // Create an HttpResponseMessage with JSON content
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")
            };

            return response;
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="newCategory">The DTOCAT01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        [HttpPost]
        [Route("AddNewCategory")]
        public Response AddCategory(DTOCAT01 newCategory)
        {
            _objBLCategory.Type = EnmType.A;
            _objBLCategory.PreSave(null,newCategory);
            _objResponse = _objBLCategory.Validation();
            if(!_objResponse.IsError)
            {
                _objResponse = _objBLCategory.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="id">The ID of the category </param>
        /// <param name="newCategory">The DTOCAT01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        [HttpPut]
        [Route("UpdateCategory")]
        public Response UpdateCategory(int id, DTOCAT01 newCategory)
        {
            _objBLCategory.Type = EnmType.E;
            _objBLCategory.PreSave(id, newCategory);
            _objResponse = _objBLCategory.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLCategory.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="id">The ID of the category</param>
        /// <returns>An HttpResponseMessage indicating the outcome of the deletion operation.</returns>
        [HttpDelete]
        [Route("DeleteCategory")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            bool response = _objBLCategory.Delete(id);
            if (response)
            {
                // If the category is successfully deleted, return HTTP OK status
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // If there is an internal server error during category deletion, return HTTP InternalServerError status
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

    }
}
