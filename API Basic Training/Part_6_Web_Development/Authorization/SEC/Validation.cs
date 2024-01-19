using Authorization.Controllers;
using Authorization.Models;
using System.Linq;

namespace Authorization.SEC
{
    /// <summary>
    /// Provides methods for validating user credentials and retrieving user details.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Validates user login credentials.
        /// </summary>
        /// <param name="username">The username to be validated.</param>
        /// <param name="password">The password to be validated.</param>
        /// <returns>True if the credentials are valid, otherwise false.</returns>
        public static bool Login(string username, string password)
        {
            // Retrieve the list of employees from the controller
            var list = EmployeeController.employeeList;

            // Check if there is any employee with matching username and password
            return list.Any(emp => emp.EmployeeName.Equals(username) && emp.Password.Equals(password));
        }

        /// <summary>
        /// Retrieves user details based on the provided username.
        /// </summary>
        /// <param name="username">The username for which to retrieve details.</param>
        /// <param name="password">The password for additional validation (not used here).</param>
        /// <returns>The Employee object associated with the username, or null if not found.</returns>
        public static Employee UserDetails(string username, string password)
        {
            // Retrieve the list of employees from the controller
            var list = EmployeeController.employeeList;

            // Find the employee with the matching username
            return list.FirstOrDefault(emp => emp.EmployeeName.Equals(username));
        }
    }
}