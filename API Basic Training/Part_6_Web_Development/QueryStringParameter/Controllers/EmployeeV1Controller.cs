using QueryStringParameter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueryStringParameter.Controllers
{
    /// <summary>
    /// Controller for managing employee data with version 1 of the API.
    /// </summary>
    public class EmployeeV1Controller : ApiController
    {
        /// <summary>
        /// Represents a static list of employees for version 1.
        /// </summary>
        public static List<EmployeeV1> employeeList = new List<EmployeeV1>
        {
            new EmployeeV1 { EmployeeID = 1, EmployeeName = "Jeet"},
            new EmployeeV1 { EmployeeID = 2, EmployeeName = "Tony Stark" },
            new EmployeeV1 { EmployeeID = 3, EmployeeName = "Spider-Man" },
            new EmployeeV1 { EmployeeID = 4, EmployeeName = "Hulk" },
            new EmployeeV1 { EmployeeID = 5, EmployeeName = "Thor" },
            new EmployeeV1 { EmployeeID = 6, EmployeeName = "Black Widow" },
            new EmployeeV1 {EmployeeID = 7, EmployeeName = "Captain America"},
            new EmployeeV1 {EmployeeID = 8, EmployeeName = "Doctor Strange"},
            new EmployeeV1 {EmployeeID = 9, EmployeeName = "Black Panther"},
            new EmployeeV1 {EmployeeID = 10, EmployeeName = "Captain Marvel"}
        };

        /// <summary>
        /// Retrieves a list of employees for version 1 of the API.
        /// </summary>
        /// <returns>An IHttpActionResult containing the list of employees.</returns>
        public IHttpActionResult Get()
        {
            return Ok(employeeList);
        }

    }

}
