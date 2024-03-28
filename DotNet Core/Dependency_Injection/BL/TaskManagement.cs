using Dependency_Injection.Interface;
using Dependency_Injection.Models;

namespace Dependency_Injection.BL
{
    /// <summary>
    /// TaskManagement to manage tasks.
    /// </summary>
    public class TaskManagement : ITaskManagement
    {
        // Static list of dummy task
        private readonly List<Models.Task> _tasks = new List<Models.Task>
            {
                new Models.Task { Id = 1, Title = "Modual Release", Description = "Check Db Connection Before Modual Released" },
                new Models.Task { Id = 2, Title = "Fixed Bug", Description = "Fixed Bug Priority Level : High" }
            };

        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>An enumerable collection of tasks.</returns>
        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _tasks;
        }

        /// <summary>
        /// Retrieves a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task</param>
        /// <returns>The task with the specified ID</returns>
        public Models.Task GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}
