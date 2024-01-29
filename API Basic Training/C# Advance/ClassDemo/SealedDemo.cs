using System;

namespace Abstract
{
    /// <summary>
    /// Sealed class representing an admin system.
    /// </summary>
    public sealed class AdminSystem
    {
        /// <summary>
        /// Constructor for AdminSystem class.
        /// </summary>
        public AdminSystem()
        {
            Console.WriteLine("Admin System Started");
        }

        /// <summary>
        /// Method to perform admin login.
        /// </summary>
        public void Login()
        {
            Console.WriteLine("Admin Login");
        }

        /// <summary>
        /// Method to perform admin logout.
        /// </summary>
        public void LogOut()
        {
            Console.WriteLine("Admin Logout");
        }
    }
    // we cannot dirive sealed class
    //public class EmployeeSystem : AdminSystem
    //{

    //}

    /// <summary>
    /// class SealedDemo containing a method to demonstrate the usage of sealed classes.
    /// </summary>
    public class SealedDemo
    {
        public static void SealedClassTest(string[] args)
        {
            // Creating an instance of the AdminSystem class
            AdminSystem objofAdminSystem = new AdminSystem();
            objofAdminSystem.Login();
            objofAdminSystem.LogOut();
        }
    }
}
