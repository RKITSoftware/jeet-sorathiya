using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
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
        private BLCategory _category;

        /// <summary>
        /// Gets all categories and returns them as JSON
        /// </summary>
        [HttpGet]
        [Route("Category")]
        public HttpResponseMessage GetAllCategory()
        {
            _category = new BLCategory();
            DataTable dataTableOfCategory = _category.GetAll();

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
        /// Adds a new category
        /// </summary>
        [HttpPost]
        [Route("AddNewCategory")]
        public HttpResponseMessage AddCategory(CAT01 newCategory)
        {
            _category = new BLCategory();
            bool response = _category.Add(newCategory);
            if (response)
            {
                // If the category is successfully added, return HTTP OK status
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // If there is an internal server error during category addition, return HTTP InternalServerError status
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Updates an existing category by ID
        /// </summary>
        [HttpPut]
        [Route("UpdateCategory")]
        public HttpResponseMessage UpdateCategory(int id, CAT01 newCategory)
        {
            _category = new BLCategory();
            bool response = _category.Update(id, newCategory);
            if (response)
            {
                // If the category is successfully updated, return HTTP OK status
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // If there is an internal server error during category update, return HTTP InternalServerError status
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Deletes a category by ID
        /// </summary>
        [HttpDelete]
        [Route("DeleteCategory")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            _category = new BLCategory();
            bool response = _category.Delete(id);
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
