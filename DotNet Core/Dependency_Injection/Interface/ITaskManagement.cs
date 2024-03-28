using Dependency_Injection.Models;

namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for managing tasks.
    /// </summary>
    public interface ITaskManagement
    {
        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>An enumerable collection of tasks.</returns>
        IEnumerable<Models.Task> GetAllTasks();

        /// <summary>
        /// Retrieves a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        /// <returns>The task with the specified ID</returns>
        Models.Task GetTaskById(int id);
    }
}
