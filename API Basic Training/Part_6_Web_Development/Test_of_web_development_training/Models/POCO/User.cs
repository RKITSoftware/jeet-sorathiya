using System.Collections.Generic;
using System.Linq;

namespace Test_of_web_development_training.Models.POCO
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

    }
}