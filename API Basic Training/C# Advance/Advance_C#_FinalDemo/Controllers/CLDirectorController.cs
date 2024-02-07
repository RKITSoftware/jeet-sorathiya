using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private BLDirector _director;

        /// <summary>
        /// Gets all directors and returns them as JSON
        /// </summary>
        [HttpGet]
        [Route("Director")]
        public HttpResponseMessage GetAllCategory()
        {
            _director = new BLDirector();
            DataTable dataTableOfDirector = _director.GetAll();

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
        /// Adds a new director
        /// </summary>
        [HttpPost]
        [Route("AddNewDirector")]
        public HttpResponseMessage AddDirector(DIR01 newDirector)
        {
            _director = new BLDirector();
            bool response = _director.Add(newDirector);
            if (response)
            {
                // If the director is successfully added, return HTTP OK status
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // If there is an internal server error during director addition, return HTTP InternalServerError status
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Updates an existing director by ID
        /// </summary>
        [HttpPut]
        [Route("UpdateDirector")]
        public HttpResponseMessage UpdateCategory(int id, DIR01 newDirector)
        {
            _director = new BLDirector();
            bool response = _director.Update(id, newDirector);
            if (response)
            {
                // If the director is successfully updated, return HTTP OK status
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // If there is an internal server error during director update, return HTTP InternalServerError status
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Deletes a director by ID
        /// </summary>
        [HttpDelete]
        [Route("DeleteDirector")]
        public HttpResponseMessage DeleteDirector(int id)
        {
            _director = new BLDirector();
            bool response = _director.Delete(id);
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
