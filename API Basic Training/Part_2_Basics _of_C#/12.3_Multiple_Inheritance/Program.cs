using System;

namespace _12._3_Multiple_Inheritance
{
    #region interface IUser
    /// <summary>
    /// Interface IUser
    /// </summary>
    public interface IUser
    {
        string UserName { get; set; }
        void Login();
        void Logout();
    }
    #endregion

    #region interface IAdmin
    /// <summary>
    /// Interface admin.
    /// </summary>
    public interface IAdmin
    {
        void GrantAdminRights();
    }
    #endregion

    #region Interface IEmployee
    /// <summary>
    /// Interface IEmployee
    /// </summary>
    public interface IEmployee
    {
        void Work();
    }
    #endregion

    #region class RegularUser
    /// <summary>
    /// Class RegularUser
    /// </summary>
    public class RegularUser : IUser
    {
        #region field
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string UserName { get; set; }
        #endregion

        #region method
        /// <summary>
        /// Login the regular user.
        /// </summary>
        public void Login()
        {
            Console.WriteLine($"{UserName} logged in.");
        }
        /// <summary>
        /// Logout the regular user.
        /// </summary>
        public void Logout()
        {
            Console.WriteLine($"{UserName} logged out.");
        }
        #endregion
    }
    #endregion

    #region class AdminUser
    /// <summary>
    /// Class AdminUser
    /// </summary>
    public class AdminUser : IUser, IAdmin
    {

        #region field
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string UserName { get; set; }
        #endregion

        #region method
        /// <summary>
        /// Login method
        /// </summary>
        public void Login()
        {
            Console.WriteLine($"Admin : {UserName} logged in.");
        }

        /// <summary>
        /// Logout method
        /// </summary>
        public void Logout()
        {
            Console.WriteLine($"Admin : {UserName} logged out.");
        }

        /// <summary>
        /// GrantAdminRights method
        /// </summary>
        public void GrantAdminRights()
        {
            Console.WriteLine($"{UserName} granted admin rights.");
        }
        #endregion
    }
    #endregion

    #region class Employee
    /// <summary>
    /// Class employee.
    /// </summary>
    public class Employee : IUser, IEmployee
    {
        #region field
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string UserName { get; set; }
        #endregion

        #region method
        /// <summary>
        /// Login the employee.
        /// </summary>
        public void Login()
        {
            Console.WriteLine($"Employee : {UserName} logged in.");
        }

        /// <summary>
        /// Logout the employee.
        /// </summary>
        public void Logout()
        {
            Console.WriteLine($"Employee : {UserName} logged out.");
        }

        /// <summary>
        ///  method work.
        /// </summary>
        public void Work()
        {
            Console.WriteLine($"{UserName} is working.");
        }
        #endregion
    }
    #endregion

    #region class Program
    internal class Program
    {
        #region main method
        /// <summary>
        /// main method
        /// </summary>
        static void Main()
        {

            RegularUser objofRegularUser = new RegularUser { UserName = "Meet" };
            AdminUser objofAdminUser = new AdminUser { UserName = "Jeet" };
            Employee objodEmployee = new Employee { UserName = "Neel" };


            objofRegularUser.Login();
            objofRegularUser.Logout();

            objofAdminUser.Login();
            objofAdminUser.GrantAdminRights();
            objofAdminUser.Logout();

            objodEmployee.Login();
            objodEmployee.Work();
            objodEmployee.Logout();
        }
        #endregion
    }
    #endregion
}
