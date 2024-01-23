using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exception.Models
{
    /// <summary>
    /// Represents an employee with basic information.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the role of the employee.
        /// </summary>
        public string EmployeeRole { get; set; }

        /// <summary>
        /// Gets or sets the password associated with the employee's account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee's account is active.
        /// </summary>
        public bool IsActive { get; set; }
    }

}