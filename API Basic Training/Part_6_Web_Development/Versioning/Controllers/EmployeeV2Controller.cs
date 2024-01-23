using System.Collections.Generic;
using System.Web.Http;
using Versioning.Models;

namespace Versioning.Controllers
{
    /// <summary>
    /// Controller for managing employee data with version 2 of the API.
    /// </summary>
    public class EmployeeV2Controller : ApiController
    {
        /// <summary>
        /// Represents a static list of employees for version 2.
        /// </summary>
        public static List<EmployeeV2> employeeList = new List<EmployeeV2>
        {
            new EmployeeV2 { EmployeeID = 1, EmployeeName = "Jeet", EmployeeDescription = "Leader" },
            new EmployeeV2 { EmployeeID = 2, EmployeeName = "Tony Stark", EmployeeDescription = "Iron Man" },
            new EmployeeV2 { EmployeeID = 3, EmployeeName = "Spider-Man", EmployeeDescription = "Superhero" },
            new EmployeeV2 { EmployeeID = 4, EmployeeName = "Hulk", EmployeeDescription = "Gamma Scientist" },
            new EmployeeV2 { EmployeeID = 5, EmployeeName = "Thor", EmployeeDescription = "God of Thunder" },
            new EmployeeV2 { EmployeeID = 6, EmployeeName = "Black Widow", EmployeeDescription = "Espionage Expert" },
            new EmployeeV2 { EmployeeID = 7, EmployeeName = "Captain America", EmployeeDescription = "Super Soldier" },
            new EmployeeV2 { EmployeeID = 8, EmployeeName = "Doctor Strange", EmployeeDescription = "Sorcerer Supreme" },
            new EmployeeV2 { EmployeeID = 9, EmployeeName = "Black Panther", EmployeeDescription = "King of Wakanda" },
            new EmployeeV2 { EmployeeID = 10, EmployeeName = "Captain Marvel", EmployeeDescription = "Cosmic Avenger" }
        };

        /// <summary>
        /// Retrieves a list of employees for version 2 of the API.
        /// </summary>
        /// <returns>An IHttpActionResult containing the list of employees.</returns>
        public IHttpActionResult Get()
        {
            return Ok(employeeList);
        }

    }
}
