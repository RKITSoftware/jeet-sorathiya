using Building_Web_API.Helper_Methods;
using Building_Web_API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Building_Web_API.Controllers
{
    /// <summary>
    /// Controller for managing employee data in a Web API.
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Static list to store sample employee data.
        /// </summary>
        static List<Employee> employeesList = new List<Employee>
        {
             // Sample employees with initial data
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Jeet Sorathiya", EmployeeDesignation = "Full Stack Developer", EmployeePhone = "9123654789", EmployeeAge = 21, IsActive = true},
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Tony Stark", EmployeeDesignation = "Project Coordinator", EmployeePhone = "7456321589", EmployeeAge = 35, IsActive = false},
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Captain America", EmployeeDesignation = "HR", EmployeePhone = "9214536875", EmployeeAge = 100, IsActive = true},
            new Employee{EmployeeID = HelperMethods.newEmpID(), EmployeeName = "Spiderman", EmployeeDesignation = "Trainee", EmployeePhone = "6589321456", EmployeeAge = 18, IsActive = true},
        };


        /// <summary>
        ///  GET : api/Employee, Retrieves all employees.
        /// </summary>
        /// <returns>List of employees.</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            // Returning a response with the list of employees
            return Ok(employeesList);
        }

        /// <summary>
        /// GET : api/Employee/{id}, Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        /// <returns>Employee with the specified ID.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            // Returning a response with the employee matching the given ID
            return Ok(employeesList.Find(employee => employee.EmployeeID == id));
        }

        /// <summary>
        /// POST : api/Employee, Adds a new employee
        /// </summary>
        /// <param name="employee">Employee data to be added.</param>
        /// <returns>List of employees after adding the new employee.</returns>
        [HttpPost]
        public IHttpActionResult Post(Employee employee)
        {
            // Generating a new employee ID and adding the new employee to the list
            employee.EmployeeID = HelperMethods.newEmpID();
            employeesList.Add(employee);
            // Returning a response with the updated list of employees
            return Ok(employeesList);
        }

        /// <summary>
        ///  PUT : api/Employee/{id}, Updates an existing employee by ID.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        /// <param name="newEmployee">Updated employee data.</param>
        /// <returns>Updated employee details.</returns>
        [HttpPut]
        public IHttpActionResult Put(int id, Employee newEmployee)
        {
            // Finding the current employee in the list
            Employee currentEmployee = employeesList.Find(employee => employee.EmployeeID == id);
            
            // Checking if the employee exists
            if (currentEmployee == null)
            {
                //Console.WriteLine("Employee Not Found At this ID");
                return NotFound();
            }
            // Updating employee details
            currentEmployee.EmployeeName = newEmployee.EmployeeName;
            currentEmployee.EmployeeDesignation = newEmployee.EmployeeDesignation;
            currentEmployee.EmployeePhone = newEmployee.EmployeePhone;
            currentEmployee.EmployeeAge = newEmployee.EmployeeAge;

            // Returning a response with the updated employee
            return Ok(currentEmployee);
        }

        /// <summary>
        ///  DELETE : api/Employee/{id}, Deletes an employee by ID.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        /// <returns>Deleted employee details.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            // Finding the current employee in the list
            var deleteEmployee = employeesList.Find(employee => employee.EmployeeID == id);
            // Checking if the employee exists
            if (deleteEmployee == null)
            {
                // Returning a Not Found response
                return NotFound();
            }
            // Removing the employee from the list
            employeesList.Remove(deleteEmployee);
            // Returning a response with the deleted employee
            return Ok(deleteEmployee);
        }
    }
}
