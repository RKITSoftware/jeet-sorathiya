namespace Authentication.Models
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
        /// Gets or sets the designation or role of the employee.
        /// </summary>
        public string EmployeeDesignation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is currently active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
