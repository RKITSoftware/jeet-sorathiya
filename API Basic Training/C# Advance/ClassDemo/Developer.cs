using System;

namespace Employees
{
    #region partial class Employee
    /// <summary>
    /// Partial class representing an Employee with additional functionality related to development tasks.
    /// </summary>
    public partial class Employee
    {
        /// <summary>
        /// Method to perform developer login.
        /// </summary>
        public void DeveloperLogin()
        {
            Console.WriteLine("Developer Login");
        }

        /// <summary>
        /// Method to perform a task related to development
        public void DeveloperTask()
        {
            Console.WriteLine("Work on Bug-Report Sheet");
        }

        /// <summary>
        /// Method to perform developer logout.
        /// </summary>
        public void DeveloperLogout()
        {
            Console.WriteLine("Developer Logout");
        }
    }
    #endregion
}
