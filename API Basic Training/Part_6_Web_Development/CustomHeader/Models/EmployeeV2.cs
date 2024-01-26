namespace CustomHeader.Models
{
    /// <summary>
    /// Represents an employee with extended information for version 2 of the API.
    /// </summary>
    public class EmployeeV2
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