using Authorization.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization.BL
{
    /// <summary>
    /// Business logic class for managing employee-related operations.
    /// </summary>
    public class BLEmployee
    {
        /// <summary>
        /// Static list of employees
        /// </summary>
        static readonly List<Employee> employeeList = new List<Employee>
        {
            new Employee{EmployeeID = 1, EmployeeName = "Jeet", EmployeeRole = "Admin", IsActive = true,  Password = "1234"},
            new Employee{EmployeeID = 2,EmployeeName = "Tony-Stark", EmployeeRole = "Cordinator", IsActive = true, Password = "1234"},
            new Employee{EmployeeID = 3,EmployeeName = "SpiderMan", EmployeeRole = "Trainee", IsActive = !true, Password = "1234"},
            new Employee{EmployeeID = 4,EmployeeName = "hokai", EmployeeRole = "Trainee", IsActive = !true, Password = "1234"},
        };

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>An IEnumerable of all employees.</returns>
        public IEnumerable<Employee> GetAll()
        {
            return employeeList;
        }

        /// <summary>
        /// Retrieves all trainee employees.
        /// </summary>
        /// <returns>An IEnumerable of trainee employees.</returns>
        public IEnumerable<Employee> GetAllTrainee()
        {
            return employeeList.FindAll(emp => emp.EmployeeRole.Equals("Trainee"));
        }

        /// <summary>
        /// Retrieves information of the currently authenticated user.
        /// </summary>
        /// <returns>The Employee object of currently authenticated user.</returns>
        public Employee GetInfo()
        {
            // Get the name of the currently authenticated user
            string name = HttpContext.Current.User.Identity.Name;
            return employeeList.Find(emp => emp.EmployeeName.Equals(name));
        }

        /// <summary>
        /// Validates user login credentials.
        /// </summary>
        /// <param name="username">The username </param>
        /// <param name="password">The password </param>
        /// <returns>True if login credentials are valid, otherwise false.</returns>
        public bool Login(string username, string password)
        {
            return employeeList.Any(emp => emp.EmployeeName.Equals(username) && emp.Password.Equals(password));
        }

        /// <summary>
        /// Retrieves details of a user
        /// </summary>
        /// <param name="username">username </param>
        /// <param name="password">password </param>
        /// <returns>The Employee object representing the user</returns>
        public Employee UserDetails(string username, string password)
        {
            // Find the employee with the matching username
            return employeeList.FirstOrDefault(emp => emp.EmployeeName.Equals(username) && emp.Password.Equals(password));
        }
    }
}