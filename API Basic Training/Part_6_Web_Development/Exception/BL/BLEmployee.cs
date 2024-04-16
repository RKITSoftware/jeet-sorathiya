using Exception.Models;
using System.Collections.Generic;

namespace Exception.BL
{
    /// <summary>
    /// Business logic class for managing employees.
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
            new Employee{EmployeeID = 4,EmployeeName = "Hawkeye", EmployeeRole = "Trainee", IsActive = !true, Password = "1234"},
        };

        /// <summary>
        /// Retrieves all employees
        /// </summary>
        /// <returns>List of all employees</returns>
        public IEnumerable<Employee> GetAll()
        {
            return employeeList;
        }

        /// <summary>
        /// Retrieves all trainee employees
        /// </summary>
        /// <returns>List of all trainee employees</returns>
        public IEnumerable<Employee> GetAllTrainee()
        {
            return employeeList.FindAll(emp => emp.EmployeeRole.Equals("Trainee"));
        }

        /// <summary>
        /// Throws a KeyNotFoundException
        /// </summary>
        /// <exception cref="KeyNotFoundException">Thrown when employee information try to fetch</exception>
        public Employee GetInfo()
        {
            throw new KeyNotFoundException();
        }
    }
}