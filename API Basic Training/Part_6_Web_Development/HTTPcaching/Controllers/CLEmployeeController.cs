using HTTPcaching.BL;
using System.Net.Http;
using System.Web.Http;

namespace HTTPcaching.Controllers
{
    [RoutePrefix("api/Employee")]
    public class CLEmployeeController : ApiController
    {
        private static BLCacheManager _blCacheManager = new BLCacheManager();

        BLEmployee _blEmployee;
        public CLEmployeeController()
        {
            _blEmployee = new BLEmployee();
        }


        [Route("Get")]
        public HttpResponseMessage Get()
        {
            return _blCacheManager.GetCachedResponse(Request, FetchData);
        }

   
        private object FetchData()
        {
            return _blEmployee.GetAll();
        }
    }
}
