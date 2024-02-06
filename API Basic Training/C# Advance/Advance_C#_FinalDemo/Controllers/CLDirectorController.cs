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
    [RoutePrefix("api/Director")]
    public class CLDirectorController : ApiController
    {
        private BLDirector _director;

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

        [HttpPost]
        [Route("AddNewDirector")]
        public HttpResponseMessage AddDirector(DIR01 newDirector)
        {
            _director = new BLDirector();
            bool response = _director.Add(newDirector);
            if (response)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        [Route("UpdateDirector")]
        public HttpResponseMessage UpdateCategory(int id, DIR01 newDirector)
        {
            _director = new BLDirector();
            bool response = _director.Update(id, newDirector);
            if (response)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteDirector")]
        public HttpResponseMessage DeleteDirector(int id)
        {
            _director = new BLDirector();
            bool response = _director.Delete(id);
            if (response)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
