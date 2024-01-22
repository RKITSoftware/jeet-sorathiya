using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Token.Controllers;
using Token.Models;

namespace Token.TokenAuth
{
    /// <summary>
    /// Class responsible for validating employee credentials.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Checks if the provided username and password correspond to a valid employee.
        /// </summary>
        /// <param name="username">The username to be validated.</param>
        /// <param name="password">The password to be validated.</param>
        /// <returns>True if the employee is valid; otherwise, false.</returns>
        public bool Isemployee(string username, string password)
        {
            var employeeList = EmployeeController.employeeList;
            // Check if the employee list is not empty
            if (employeeList.Count > 0)
            {
                // Check if there is any employee with the provided username and password
                return (employeeList.Any(emp => emp.EmployeeName.Equals(username) && emp.Password.Equals(password)));
            }
            return false;
        }

        /// <summary>
        /// Retrieves details of an employee based on the provided username and password.
        /// </summary>
        /// <param name="username">The username to retrieve details for.</param>
        /// <param name="password">The password to retrieve details for.</param>
        /// <returns>The Employee object if found; otherwise, null.</returns>
        public Employee EmployeeDetail(string username, string password)
        {
            var employeeList = EmployeeController.employeeList;
            // Find and return the first employee with the provided username and password
            return (employeeList.FirstOrDefault(emp => emp.EmployeeName.Equals(username) && emp.Password.Equals(password)));
        }
    }
}