using Authentication.Models;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.BL
{
    /// <summary>
    /// Business logic class for managing employee-related operations.
    /// </summary>
    public class BLEmployee
    {
        // list of employees
        static readonly List<Employee> employeeList = new List<Employee>
        {
            new Employee { EmployeeID = 1, EmployeeName = "Jeet", EmployeeDesignation = "TeamLead", IsActive = true },
        };

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>All employees.</returns>
        public IEnumerable<Employee> GetAll()
        {
            return employeeList;
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee</param>
        /// <returns>The Employee object with the ID</returns>
        public Employee GetByID(int id)
        {
            // Retrieve the employee with the specified ID
            return employeeList.FirstOrDefault(emp => emp.EmployeeID == id);
        }

    }
}