namespace File_System.Models
{
    /// <summary>
    /// Represents an Employee with basic information.
    /// </summary>
    public class Employee
    {
        // static id for EmployeeId
        private static int Id = 100;

        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the job title of the employee.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets the next available EmployeeID and increments the static counter.
        /// </summary>
        /// <returns>The next available EmployeeID.</returns>
        public static int GetEmployeeID()
        {
            return Id++;
        }
    }
}