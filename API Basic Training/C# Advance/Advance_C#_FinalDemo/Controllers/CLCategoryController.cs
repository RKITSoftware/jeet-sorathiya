using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Advance_C__FinalDemo.Controllers
{
    [RoutePrefix("api/Category")]
    public class CLCategoryController : ApiController
    {
        private BLCategory _category;
       
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

        [HttpPost]
        [Route("AddNewCategory")]
        public HttpResponseMessage AddCategory(CAT01 newCategory)
        {
            _category = new BLCategory();
            bool response = _category.Add(newCategory);
            if (response)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public HttpResponseMessage UpdateCategory(int id, CAT01 newCategory)
        {
            _category = new BLCategory();
            bool response = _category.Update(id, newCategory);
            if (response)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            _category = new BLCategory();
            bool response = _category.Delete(id);
            if (response)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

    }
}
