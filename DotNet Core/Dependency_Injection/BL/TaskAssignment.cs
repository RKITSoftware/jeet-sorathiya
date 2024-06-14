using Dependency_Injection.Interface;
using Dependency_Injection.Models;

namespace Dependency_Injection.BL
{
    /// <summary>
    /// TaskAssignment for task assignment.
    /// </summary>
    public class TaskAssignment : ITaskAssignment
    {
        #region Private Field
        private readonly ITaskManagement _taskManagement;
        private readonly IEmployeeManagement _employeeManagement;
        private List<Assignment> _assignments = new List<Assignment>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskAssignment"/> class.
        /// </summary>
        /// <param name="taskManagement">task management object</param>
        /// <param name="employeeManagement">employee management object</param>
        public TaskAssignment(ITaskManagement taskManagement, IEmployeeManagement employeeManagement)
        {
            _taskManagement = taskManagement;
            _employeeManagement = employeeManagement;

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns a task to an employee.
        /// </summary>
        /// <param name="taskId">The ID of the task</param>
        /// <param name="employeeId">The ID of the employee</param>
        public void AssignTaskToEmployee(int taskId, int employeeId)
        {
            // Check if the task and employee exist
            if (!_taskManagement.GetAllTasks().Any(t => t.Id == taskId))
            {
                throw new ArgumentException("Task does not exist.");
            }

            if (!_employeeManagement.GetAllEmployees().Any(e => e.Id == employeeId))
            {
                throw new ArgumentException("Employee does not exist.");
            }

            // Check if the assignment already exists
            if (_assignments.Any(a => a.TaskId == taskId && a.EmployeeId == employeeId))
            {
                throw new ArgumentException("Task already assigned to employee.");
            }

            else
            {
                // create and add the assignment
                var assignment = new Assignment { TaskId = taskId, EmployeeId = employeeId };
                _assignments.Add(assignment);
            }

        }

        /// <summary>
        /// Retrieves all assignments for a task.
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        /// <returns>An enumerable collection of assignments</returns>
        public IEnumerable<Assignment> GetAssignmentsForTask(int taskId)
        {
            return _assignments.Where(a => a.TaskId == taskId);
        } 
        #endregion
    }
}
