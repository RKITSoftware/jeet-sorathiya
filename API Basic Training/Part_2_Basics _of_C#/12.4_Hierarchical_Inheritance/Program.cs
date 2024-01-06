using System;

namespace _12._4_Hierarchical_Inheritance
{
    #region Class User
    /// <summary>
    /// Base class User
    /// </summary>
    public class User
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
        public virtual void Login()
        {
            Console.WriteLine($"{UserName} logged in.");
        }

        /// <summary>
        /// Logout method
        /// </summary>
        public virtual void Logout()
        {
            Console.WriteLine($"{UserName} logged out.");
        }
        #endregion
    }
    #endregion

    #region class RegularUser
    /// <summary>
    /// class RegularUser
    /// </summary>
    public class RegularUser : User
    {
        #region method
        /// <summary>
        /// Login method
        /// </summary>
        public override void Login()
        {
            Console.WriteLine($"{UserName} (Regular User) logged in.");
        }

        /// <summary>
        ///RegularUserSpecific method
        /// </summary>
        public void RegularUserSpecific()
        {
            Console.WriteLine($"{UserName} performing a regular action.");
        }
        #endregion
    }
    #endregion

    #region class AdminUser
    /// <summary>
    /// Class admin user, inheriting from the User class.
    /// </summary>
    public class AdminUser : User
    {
        #region method
        /// <summary>
        /// login method
        /// </summary>
        public override void Login()
        {
            Console.WriteLine($"{UserName} (Admin) logged in.");
        }

        /// <summary>
        /// Grants admin rights method
        /// </summary>
        public void GrantAdminRights()
        {
            Console.WriteLine($"{UserName} granted admin rights.");
        }
        #endregion
    }
    #endregion

    #region class SubAdminUser
    /// <summary>
    /// Class representing a sub-admin user, inheriting from AdminUser.
    /// </summary>
    public class SubAdminUser : AdminUser
    {
        #region method
        /// <summary>
        /// Adds a specific method for sub-admin users.
        /// </summary>
        public void SubAdminSpecific()
        {
            Console.WriteLine($"{UserName} performing a sub-admin-specific action.");
        }
        #endregion
    }
    #endregion

    #region class SubRegularUser
    /// <summary>
    /// Class sub-regular user, inheriting from RegularUser.
    /// </summary>
    public class SubRegularUser : RegularUser
    {
        #region method
        /// <summary>
        /// method SubRegularSpecific
        /// </summary>
        public void SubRegularSpecific()
        {
            Console.WriteLine($"{UserName} performing a sub-regular-specific action.");
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
            // Example usage
            RegularUser regularUser = new RegularUser { UserName = "RegularUser369" };
            AdminUser adminUser = new AdminUser { UserName = "Jeet" };
            SubAdminUser subAdminUser = new SubAdminUser { UserName = "SubAdmin123" };
            SubRegularUser subRegularUser = new SubRegularUser { UserName = "SubRegular789" };

            // Perform actions for each user type
            regularUser.Login();
            regularUser.RegularUserSpecific();
            regularUser.Logout();

            adminUser.Login();
            adminUser.GrantAdminRights();
            adminUser.Logout();

            subAdminUser.Login();
            subAdminUser.GrantAdminRights();
            subAdminUser.SubAdminSpecific();
            subAdminUser.Logout();

            subRegularUser.Login();
            subRegularUser.RegularUserSpecific();
            subRegularUser.SubRegularSpecific();
            subRegularUser.Logout();
        }
        #endregion
    }
    #endregion
}

