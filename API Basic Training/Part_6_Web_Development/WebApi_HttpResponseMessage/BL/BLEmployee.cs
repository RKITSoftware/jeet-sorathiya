using System.Collections.Generic;
using WebApi_HttpResponseMessage.Controllers;
using WebApi_HttpResponseMessage.Models;

namespace WebApi_HttpResponseMessage.BL
{
    /// <summary>
    /// Business logic class for managing employee data.
    /// </summary>
    public class BLEmployee
    {
        /// <summary>
        /// Static list to store employee data.
        /// </summary>
        static readonly List<Employee> employeesList = new List<Employee>
        {
             // Sample employees with initial data
            new Employee{EmployeeID = HelperMethods.NewEmpID(), EmployeeName = "Jeet Sorathiya", EmployeeDesignation = "Full Stack Developer", EmployeePhone = "9123654789", EmployeeAge = 21, IsActive = true},
            new Employee{EmployeeID = HelperMethods.NewEmpID(), EmployeeName = "Tony Stark", EmployeeDesignation = "Project Coordinator", EmployeePhone = "7456321589", EmployeeAge = 35, IsActive = false},
            new Employee{EmployeeID = HelperMethods.NewEmpID(), EmployeeName = "Captain America", EmployeeDesignation = "HR", EmployeePhone = "9214536875", EmployeeAge = 100, IsActive = true},
            new Employee{EmployeeID = HelperMethods.NewEmpID(), EmployeeName = "Spiderman", EmployeeDesignation = "Trainee", EmployeePhone = "6589321456", EmployeeAge = 18, IsActive = true},
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
        public Employee GetById(int id)
        {
            return employeesList.Find(employee => employee.EmployeeID == id);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee object to add.</param>
        /// <returns>Returns a collection of all employees after adding the new employee.</returns>
        public IEnumerable<Employee> Add(Employee employee)
        {
            // Generating a new employee ID and adding the new employee to the list
            employee.EmployeeID = HelperMethods.NewEmpID();
            employeesList.Add(employee);

            return employeesList;
        }

        /// <summary>
        /// Updates an employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="newEmployee">The updated employee object.</param>
        /// <returns>Returns the updated employee.</returns>
        public Employee Update(int id, Employee newEmployee)
        {
            // Finding the current employee in the list
            Employee currentEmployee = employeesList.Find(employee => employee.EmployeeID == id);

            // Checking if the employee exists
            if (currentEmployee == null)
            {
                return null;
            }
            // Updating employee details
            currentEmployee.EmployeeName = newEmployee.EmployeeName;
            currentEmployee.EmployeeDesignation = newEmployee.EmployeeDesignation;
            currentEmployee.EmployeePhone = newEmployee.EmployeePhone;
            currentEmployee.EmployeeAge = newEmployee.EmployeeAge;

            return GetById(id);
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