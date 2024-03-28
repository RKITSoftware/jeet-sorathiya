namespace Dependency_Injection.Models
{
    /// <summary>
    /// Task class representing a task.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the task.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the task.
        /// </summary>
        public string Description { get; set; }
    }
}
