using JWT.Models;
using System.Collections.Generic;
using System.Linq;

namespace JWT.BL
{
    public class BLEmployee
    {
        /// <summary>
        /// Static list of employees
        /// </summary>
        static readonly List<Employee> employeeList = new List<Employee>
        {
            new Employee{EmployeeName = "Jeet",Password = "1234"},
            new Employee{EmployeeName = "Tony-Stark", Password = "1234"},
            new Employee{EmployeeName = "SpiderMan", Password = "1234"},
            new Employee{EmployeeName = "hokai", Password = "1234"},
        };

        /// <summary>
        /// Checks if the provided employee exists in the employee list.
        /// </summary>
        /// <param name="employee">The employee to check.</param>
        /// <returns>True if the employee exists in the list, otherwise false.</returns>
        public bool IsEmployee(Employee employee)
        {
            return employeeList.Any(emp => emp.EmployeeName == employee.EmployeeName && emp.Password == employee.Password);
        }
    }
}