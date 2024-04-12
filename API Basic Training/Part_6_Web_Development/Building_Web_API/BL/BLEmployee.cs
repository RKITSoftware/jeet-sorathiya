using Building_Web_API.Helper_Methods;
using Building_Web_API.Models;
using System.Collections.Generic;

namespace Building_Web_API.BL
{
    /// <summary>
    /// Business logic class for managing employee data.
    /// </summary>
    public class BLEmployee
    {
        /// <summary>
        /// Static list to store sample employee data.
        /// </summary>
        private static readonly List<Employee> employeesList = new List<Employee>
        {
            // Sample employees with initial data
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Jeet Sorathiya", EmployeeDesignation = "Full Stack Developer", EmployeePhone = "9123654789", EmployeeAge = 21, IsActive = true},
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Tony Stark", EmployeeDesignation = "Project Coordinator", EmployeePhone = "7456321589", EmployeeAge = 35, IsActive = false},
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Captain America", EmployeeDesignation = "HR", EmployeePhone = "9214536875", EmployeeAge = 100, IsActive = true},
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Spiderman", EmployeeDesignation = "Trainee", EmployeePhone = "6589321456", EmployeeAge = 18, IsActive = true},
        };

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>Returns a collection of all employees.</returns>
        public IEnumerable<Employee> Get()
        {
            return employeesList;
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>Returns the employee with the specified ID.</returns>
        public Employee GetByID(int id)
        {
            return employeesList.Find(employee => employee.EmployeeID == id);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee object to add.</param>
        /// <returns>Returns true if the employee is successfully added; otherwise, false.</returns>
        public bool Add(Employee employee)
        {
            // Generating a new employee ID and adding the new employee to the list
            employee.EmployeeID = HelperMethods.newEmpID();
            employeesList.Add(employee);
            return true;
        }

        /// <summary>
        /// Updates an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="newEmployee">The updated employee object.</param>
        /// <returns>Returns true if the employee is successfully updated; otherwise, false.</returns>
        public bool Update(int id, Employee newEmployee)
        {
            // Finding the current employee in the list
            Employee currentEmployee = employeesList.Find(employee => employee.EmployeeID == id);

            // Checking if the employee exists
            if (currentEmployee == null)
            {
                return false;
            }

            // Updating employee details
            currentEmployee.EmployeeName = newEmployee.EmployeeName;
            currentEmployee.EmployeeDesignation = newEmployee.EmployeeDesignation;
            currentEmployee.EmployeePhone = newEmployee.EmployeePhone;
            currentEmployee.EmployeeAge = newEmployee.EmployeeAge;

            return true;
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>Returns true if the employee is successfully deleted; otherwise, false.</returns>
        public bool Delete(int id)
        {
            // Finding the current employee in the list
            var deleteEmployee = employeesList.Find(employee => employee.EmployeeID == id);

            // Checking if the employee exists
            if (deleteEmployee == null)
            {
                return false;
            }

            // Removing the employee from the list
            employeesList.Remove(deleteEmployee);
            return true;
        }
    }
}