using System.Collections.Generic;
using System.Linq;

namespace Test_of_web_development_training.Models
{
    /// <summary>
    /// Represents a user 
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique id of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user (e.g., Admin, Subscriber, NonSubscriber).
        /// </summary>
        public string Role { get; set; }

        // A static list to store user data
        private static List<User> userList = new List<User>
        {
            new User{Id=1,UserName="Jeet",Password="1234",Role="Admin"},
            new User{Id=2,UserName="U1",Password = "1234",Role="Subscriber"},
            new User{Id=3,UserName="U2",Password = "1234",Role = "NonSubscriber"}
        };

        /// <summary>
        /// Gets the list of all users.
        /// </summary>
        /// <returns>The list of users.</returns>
        public static List<User> GetUserList()
        {
            return userList;
        }

        /// <summary>
        /// Adds a new user to the list.
        /// </summary>
        /// <param name="newUser">The user to be added.</param>
        public static void AddNew(User newUser)
        {
            GetUserList().Add(newUser);
        }

        /// <summary>
        /// Updates the details of a user based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the user to be updated.</param>
        /// <param name="newUser">The updated user information.</param>
        public void Update(int id, User newUser)
        {
            var currentUser = userList.Find(usr => usr.Id == id);
            userList.Remove(currentUser);
            currentUser.UserName = newUser.UserName;
            currentUser.Password = newUser.Password;
            currentUser.Role = newUser.Role;
            userList.Add(currentUser);
        }

        /// <summary>
        /// Deletes a user based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        public void Delete(int id)
        {
            var currentUser = userList.Find(usr => usr.Id == id);
            userList.Remove(currentUser);
        }

        /// <summary>
        /// Retrieves user details based on the provided username.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns>The user details if found; otherwise, null.</returns>
        public static User UserDetails(string userName)
        {
            return GetUserList().Find(usr => usr.UserName == userName); ;
        }

        /// <summary>
        /// Checks if a user with the provided username and password exists.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the user exists with the provided credentials; otherwise, false.</returns>
        public static bool isUser(string userName, string password)
        {
            if (GetUserList().Any(usr => usr.UserName == userName && usr.Password == password))
            {
                return true;
            }
            return false;
        }


    }
}