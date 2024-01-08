using System;

namespace _11_Polymorphism
{
    #region Account
    /// <summary>
    /// base class account with method login.
    /// </summary>
    class Account
    {
        #region public fields
        /// <summary>
        /// Gets or sets the username,password of the account.
        /// </summary>
        public string Username { get; set; }
        public string Password { get; set; }

        #endregion

        #region public method
        /// <summary>
        /// Common login method for all accounts.
        /// </summary>
        public virtual void Login()
        {
            Console.WriteLine($"{Username} is logging in.");
        }
        #endregion
    }
    #endregion

    #region Admin
    /// <summary>
    /// Class admin, inheriting Account class.
    /// </summary>
    class Admin : Account
    {
        #region public methods
        /// <summary>
        /// Overrides the base class login method.
        /// </summary>
        public override void Login()
        {
            Console.WriteLine($"Admin {Username} is logging in.");
        }

        /// <summary>
        /// Method overloading
        /// </summary>
        /// <param name="isAdmin">True if logging in as an admin, false for a regular user.</param>
        public void Login(bool isAdmin)
        {
            if (isAdmin)
            {
                Console.WriteLine($"{Username} is logging in as an admin.");
            }
            else
            {
                Console.WriteLine($"{Username} is logging in as a regular user.");
            }
        }
        #endregion
    }
    #endregion

    #region User
    /// <summary>
    /// class user, inheriting from Account.
    /// </summary>
    class User : Account
    {
        #region public Method
        /// <summary>
        /// Overrides the base class login method for users.
        /// </summary>
        public override void Login()
        {
            Console.WriteLine($"{Username} is logging in as a user.");
        }
        #endregion
    }
    #endregion

    #region Program
    /// <summary>
    /// Contains the main entry point for the program, demonstrating polymorphism with Admin and User accounts.
    /// </summary>
    internal class Program
    {

        #region method
        /// <summary>
        /// The main method that creates instances of Admin and User, showcasing method overriding and overloading.
        /// </summary>
        static void Main()
        {
            // Create instances of Admin and User
            Admin adminAccount = new Admin
            {
                Username = "admin1",
                Password = "admin123"
            };

            User userAccount = new User
            {
                Username = "user1",
                Password = "user123"
            };

            // Demonstrate method overriding through polymorphism
            adminAccount.Login(); // Outputs: Admin admin1 is logging in.
            userAccount.Login();  // Outputs: user1 is logging in as a user.

            Console.WriteLine();

            // Demonstrate method overloading specific to Admin
            Admin admin = new Admin
            {
                Username = "admin2",
                Password = "admin456"
            };

            admin.Login();      // Outputs: Admin admin2 is logging in.
            admin.Login(true);  // Outputs: admin2 is logging in as an admin.
            admin.Login(false); // Outputs: admin2 is logging in as a regular user.
        }
        #endregion
    }
    #endregion

}
