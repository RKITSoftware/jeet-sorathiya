namespace Serialization.Models
{
    /// <summary>
    /// Represents an employee 
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique Id for the employee.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the role or employee 
        /// </summary>
        public string EmployeeRole { get; set; }

        /// <summary>
        /// Gets or sets a value employee is currently active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}