using Swagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Swagger.Controllers
{
    /// <summary>
    /// Controller for managing Employee operations.
    /// </summary>
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        // Static list to store employee data
        public static List<Employee> employeeList = new List<Employee>
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
        /// Gets all employees.
        /// </summary>
        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(employeeList);
        }

        /// <summary>
        /// Gets details of a specific employee.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        [HttpGet]
        [Route("GetEmployeeDetail")]
        public IHttpActionResult GetEmployeeDetail(int id)
        {
            return Ok(employeeList.Find(emp => emp.EmployeeID == id));
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="newEmployee">Employee object to add.</param>
        [HttpPost]
        [Route("AddNewEmployee")]
        public IHttpActionResult AddNewEmployee(Employee newEmployee)
        {
            employeeList.Add(newEmployee);
            return Ok(employeeList);
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">Employee ID to delete.</param>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var deleteEmp = employeeList.Find(emp => emp.EmployeeID == id);
            employeeList.Remove(deleteEmp);
            return Ok(employeeList);
        }

        /// <summary>
        /// Updates details of an existing employee.
        /// </summary>
        /// <param name="id">Employee ID to update.</param>
        /// <param name="newEmployee">Updated Employee object.</param>
        [HttpPut]
        [Route("UpdateDetails")]
        public IHttpActionResult UpdateDetails(int id, Employee newEmployee)
        {
            var currentEmp = employeeList.Find(emp => emp.EmployeeID == id);
            currentEmp.EmployeeID = newEmployee.EmployeeID;
            currentEmp.EmployeeName = newEmployee.EmployeeName;
            currentEmp.EmployeeDescription = newEmployee.EmployeeDescription;
            return Ok(currentEmp);
        }
    }
}
