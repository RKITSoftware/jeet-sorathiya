namespace Dependency_Injection.Models
{
    /// <summary>
    /// Assignment class representing an assignment of a task to an employee.
    /// </summary>
    public class Assignment
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// The ID of the employee.
        /// </summary>
        public int EmployeeId { get; set; }
    }
}
