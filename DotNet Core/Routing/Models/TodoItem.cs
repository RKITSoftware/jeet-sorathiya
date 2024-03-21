namespace Routing.Models
{
    /// <summary>
    /// Public TodoItem Class Represent Tasks
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Id of Task
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IsComplete is bool status of that Task 
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
