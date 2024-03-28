using Dependency_Injection.Models;

namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for managing employees.
    /// </summary>
    public interface IEmployeeManagement
    {
        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>An enumerable collection of employees.</returns>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID.</returns>
        Employee GetEmployeeById(int id);
    }
}
