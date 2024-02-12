using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.Models
{
    /// <summary>
    /// Represents an employee 
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }
    }
}