using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryStringParameter.Models
{
    /// <summary>
    /// Represents an employee with basic information for version 1 of the API.
    /// </summary>
    public class EmployeeV1
    {
        /// <summary>
        /// Gets or sets the unique ID of the employee.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }
    }
}