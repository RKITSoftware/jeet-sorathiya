namespace Authorization.Models
{
    /// <summary>
    /// Represents an employee with basic information.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the Id for the employee.
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
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value of isActive.
        /// </summary>
        public bool IsActive { get; set; }
    }
}