using Dependency_Injection.Interface;
using Dependency_Injection.Models;

namespace Dependency_Injection.BL
{
    /// <summary>
    /// EmployeeManagement to manage employees.
    /// </summary>
    public class EmployeeManagement : IEmployeeManagement
    {
        #region Private Field
        //  list of dummy data
        private List<Employee> _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Jeet" },
                new Employee { Id = 2, Name = "Meet" }
            };
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>An enumerable collection of employees.</returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee</param>
        /// <returns>The employee with the specified ID</returns>

        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        } 
        #endregion
    }
}
