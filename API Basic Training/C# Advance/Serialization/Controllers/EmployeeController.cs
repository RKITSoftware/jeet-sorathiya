using Serialization.BL;
using System.Web.Http;
using System.Xml.Linq;

namespace Serialization.Controllers
{
    /// <summary>
    /// Controller for handling data serialization.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Gets the JSON serialization of an Employee object.
        /// </summary>
        /// <returns>HTTP response with JSON serialization result.</returns>
        [HttpGet]
        [Route("JsonSerialization")]
        public IHttpActionResult JsonSerialization()
        {
            return Ok(DataSerialization.JsonSerialization());
        }

        /// <summary>
        /// Deserializes a JSON string to an Employee object
        /// </summary>
        /// <param name="json">JSON string </param>
        /// <returns>HTTP response with JSON deserialization result.</returns>
        [HttpPost]
        [Route("JsonDeserialization")]
        public IHttpActionResult JsonDeserialization([FromBody] string json)
        {
            return Ok(DataSerialization.JsonDeserialization(json));
        }

        /// <summary>
        /// Serializes an XElement 
        /// </summary>
        /// <param name="xml">XElement </param>
        /// <returns>HTTP response with XML serialization result.</returns>
        [HttpPost]
        [Route("XmlSerialization")]
        public IHttpActionResult XmlSerialization([FromBody] XElement xml)
        {
            return Ok(DataSerialization.XmlSerialization(xml));
        }

        /// <summary>
        /// Deserializes an XML
        /// </summary>
        /// <param name="xml">XML string</param>
        /// <returns>HTTP response with XML deserialization result.</returns>
        [HttpPost]
        [Route("XmlDeserialization")]
        public IHttpActionResult XmlDeserialization([FromBody] string xml)
        {
            return Ok(DataSerialization.XmlDeserialization(xml));
        }
    }
}
