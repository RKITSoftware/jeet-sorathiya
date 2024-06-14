using Newtonsoft.Json;
using Serialization.Models;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Serialization.BL
{
    /// <summary>
    /// Provides methods for data serialization and deserialization.
    /// </summary>
    public class BLDataSerialization
    {
        /// <summary>
        /// Serializes an Employee object to JSON format.
        /// </summary>
        /// <returns>JSON representation of the Employee object.</returns>
        public  string JsonSerialization()
        {
            Employee objofEmployee = new Employee { EmployeeID = 1, EmployeeName = "Jeet", EmployeeRole = "Team-Lead", IsActive = true };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(objofEmployee);

            return json;
        }

        /// <summary>
        /// Deserializes a JSON string to an Employee object.
        /// </summary>
        /// <param name="json">JSON string to be deserialized.</param>
        /// <returns>Deserialized Employee object.</returns>
        public  Employee JsonDeserialization(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee objofEmployee = serializer.Deserialize<Employee>(json);
            return objofEmployee;
        }

        /// <summary>
        /// Serializes an XElement
        /// </summary>
        /// <param name="xml">XElement to be serialized.</param>
        /// <returns>XElement.</returns>
        public  string XmlSerialization(XElement xml)
        {
          return JsonConvert.SerializeXNode(xml);
        }

        /// <summary>
        /// Deserializes an XML string
        /// </summary>
        /// <param name="xml">XML string </param>
        /// <returns>Deserialized XElement</returns>
        public  XElement XmlDeserialization(string xml)
        {
            return JsonConvert.DeserializeXNode($"{{\"Root\":{xml}}}").Root;
        }
    }
}