using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    /// <summary>
    /// Represents an Employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the ID of the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the employee.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        public string Department { get; set; }
    }

}
