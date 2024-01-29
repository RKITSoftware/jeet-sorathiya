using System;

namespace Employees
{
    #region partial class Employee
    /// <summary>
    /// Partial class representing an Employee with additional functionality related to customer support.
    /// </summary>
    public partial class Employee
    {
        /// <summary>
        /// Method to perform customer support team login.
        /// </summary
        public void CustomerSupportLogin()
        {
            Console.WriteLine("Customer Support Team Login");
        }

        /// <summary>
        /// Method to perform a task related to customer support
        /// </summary>
        public void CustomerSupportTask()
        {
            Console.WriteLine("Solve Customer Query");
        }

        /// <summary>
        /// Method to perform customer support team logout.
        /// </summary>
        public void CustomerSupportLogout()
        {
            Console.WriteLine("Logout From System");
        }
    }
    #endregion
}
