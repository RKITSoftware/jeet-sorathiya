using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swagger.Models
{
    /// <summary>
    /// Represents an employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique ID of the employee.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the additional description or details about the employee.
        /// </summary>
        public string EmployeeDescription { get; set; }
    }
}