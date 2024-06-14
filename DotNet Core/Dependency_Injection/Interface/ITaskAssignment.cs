using Dependency_Injection.Models;

namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for task assignment.
    /// </summary>
    public interface ITaskAssignment
    {
        #region Public Methods
        /// <summary>
        /// Retrieves all assignments for a task.
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        /// <returns>An enumerable collection of assignments for the specified task.</returns>
        IEnumerable<Assignment> GetAssignmentsForTask(int taskId);

        /// <summary>
        /// Assigns a task to an employee.
        /// </summary>
        /// <param name="taskId">The ID of the task to assign.</param>
        /// <param name="employeeId">The ID of the employee to assign the task to.</param>
        void AssignTaskToEmployee(int taskId, int employeeId); 
        #endregion
    }
}
