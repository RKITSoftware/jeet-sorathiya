using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Http;
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

        /// <summary>
        /// Retrieves all directors from the database.
        /// </summary>
        /// <returns>An HttpResponseMessage containing JSON of directors.</returns>
        [HttpGet]
        [Route("Director")]
        public HttpResponseMessage GetAllCategory()
        {
            DataTable dataTableOfDirector = _objBLDirector.GetAll();

            // Serialize the DataTable to JSON using Json.NET
            string jsonData = JsonConvert.SerializeObject(dataTableOfDirector);

            // Create an HttpResponseMessage with JSON content
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")
            };

            return response;
        }

        /// <summary>
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="newDirector">The DTODIR01 object</param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        [HttpPost]
        [Route("AddNewDirector")]
        public Response AddDirector(DTODIR01 newDirector)
        {
            _objBLDirector.Type = EnmType.A;
            _objBLDirector.PreSave(null, newDirector);
            _objResponse = _objBLDirector.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLDirector.Save();
            }
            return _objResponse;

        }

        /// <summary>
        /// Updates an existing director in the database.
        /// </summary>
        /// <param name="id">The ID of the director</param>
        /// <param name="newDirector">The DTODIR01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        [HttpPut]
        [Route("UpdateDirector")]
        public Response UpdateCategory(int id, DTODIR01 newDirector)
        {
            _objBLDirector.Type = EnmType.A;
            _objBLDirector.PreSave(id, newDirector);
            _objResponse = _objBLDirector.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLDirector.Save();
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a director from the database.
        /// </summary>
        /// <param name="id">The ID of the director </param>
        /// <returns>An HttpResponseMessage indicating the outcome of the operation.</returns>
        [HttpDelete]
        [Route("DeleteDirector")]
        public HttpResponseMessage DeleteDirector(int id)
        {

            bool response = _objBLDirector.Delete(id);
            if (response)
            {
                // If the director is successfully deleted, return HTTP OK status
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // If there is an internal server error during director deletion, return HTTP InternalServerError status
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
