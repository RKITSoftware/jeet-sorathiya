namespace Logging.Models
{
    /// <summary>
    /// Represents an employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the Id of the employee
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the employee
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the employee
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee
        /// </summary>
        public string Email { get; set; }
    }
}
