namespace Building_Web_API.Models
{
    /// <summary>
    /// Represents an employee in the system.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique id for the employee.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the designation of the employee.
        /// </summary>
        public string EmployeeDesignation { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
        public string EmployeePhone { get; set; }

        /// <summary>
        /// Gets or sets the age of the employee.
        /// </summary>
        public int EmployeeAge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is active or not.
        /// </summary>
        public bool IsActive { get; set; }

    }
}