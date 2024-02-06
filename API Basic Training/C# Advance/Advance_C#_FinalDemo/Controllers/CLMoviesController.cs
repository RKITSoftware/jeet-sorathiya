using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Advance_C__FinalDemo.BL;
using Advance_C__FinalDemo.Models;

namespace Advance_C__FinalDemo.Controllers
{
    [RoutePrefix("api/Movies")]
    public class CLMoviesController : ApiController
    {
        private BLMovies _bLMovies;

        [HttpGet]
        [Route("Movies")]
        public IHttpActionResult Movies()
        {
            _bLMovies = new BLMovies();
            return Ok(_bLMovies.GetAll());
        }

        [HttpPost]
        [Route("AddMovie")]
        public HttpResponseMessage AddNewMovie(MOV01 newMovie)
        {
            _bLMovies = new BLMovies();
            if(newMovie != null)
            {
                if(_bLMovies.Add(newMovie))
                {
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
