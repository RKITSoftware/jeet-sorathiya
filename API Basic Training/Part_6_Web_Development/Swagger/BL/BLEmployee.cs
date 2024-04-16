using Swagger.Models;
using System.Collections.Generic;

namespace Swagger.BL
{
    /// <summary>
    /// Business logic for managing employees.
    /// </summary>
    public class BLEmployee
    {
        // Static list to store employee data
        static readonly List<Employee> employeeList = new List<Employee>
        {
            new Employee { EmployeeID = 1, EmployeeName = "Jeet", EmployeeDescription = "Leader" },
            new Employee { EmployeeID = 2, EmployeeName = "Tony Stark", EmployeeDescription = "Iron Man" },
            new Employee { EmployeeID = 3, EmployeeName = "Spider-Man", EmployeeDescription = "Superhero" },
            new Employee { EmployeeID = 4, EmployeeName = "Hulk", EmployeeDescription = "Gamma Scientist" },
            new Employee { EmployeeID = 5, EmployeeName = "Thor", EmployeeDescription = "God of Thunder" },
            new Employee { EmployeeID = 6, EmployeeName = "Black Widow", EmployeeDescription = "Espionage Expert" },
            new Employee { EmployeeID = 7, EmployeeName = "Captain America", EmployeeDescription = "Super Soldier" },
            new Employee { EmployeeID = 8, EmployeeName = "Doctor Strange", EmployeeDescription = "Sorcerer Supreme" },
            new Employee { EmployeeID = 9, EmployeeName = "Black Panther", EmployeeDescription = "King of Wakanda" },
            new Employee { EmployeeID = 10, EmployeeName = "Captain Marvel", EmployeeDescription = "Cosmic Avenger" }
        };

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns>A collection of all employees.</returns>
        public IEnumerable<Employee> GetAll()
        {
            return employeeList;
        }

        /// <summary>
        /// Get an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID, if found; otherwise, null.</returns>
        public Employee GetById(int id)
        {
            return employeeList.Find(emp => emp.EmployeeID == id);
        }

        /// <summary>
        /// Add a new employee.
        /// </summary>
        /// <param name="newEmployee">The employee to add.</param>
        /// <returns>A collection of all employees after adding the new employee.</returns>
        public IEnumerable<Employee> Add(Employee newEmployee)
        {
            employeeList.Add(newEmployee);
            return employeeList;
        }

        /// <summary>
        /// Delete an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A collection of all employees after deleting the specified employee.</returns>
        public IEnumerable<Employee> Delete(int id)
        {
            var deleteEmp = employeeList.Find(emp => emp.EmployeeID == id);
            employeeList.Remove(deleteEmp);
            return employeeList;
        }

        /// <summary>
        /// Update an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="newEmployee">The updated information of the employee.</param>
        /// <returns>The updated employee.</returns>
        public Employee Update(int id, Employee newEmployee)
        {
            var currentEmp = employeeList.Find(emp => emp.EmployeeID == id);
            currentEmp.EmployeeID = newEmployee.EmployeeID;
            currentEmp.EmployeeName = newEmployee.EmployeeName;
            currentEmp.EmployeeDescription = newEmployee.EmployeeDescription;
            return currentEmp;
        }
    }
}