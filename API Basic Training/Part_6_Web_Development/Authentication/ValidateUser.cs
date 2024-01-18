namespace Authentication
{
    /// <summary>
    /// Provides methods for user authentication.
    /// </summary>
    public class ValidateUser
    {
        /// <summary>
        /// Validates the user's login credentials.
        /// </summary>
        /// <param name="username">The username provided by the user.</param>
        /// <param name="password">The password provided by the user.</param>
        /// <returns>True if the login is successful; otherwise, false.</returns>
        public static bool Login(string username, string password)
        {
            // Check if the provided username and password match a predefined set of credentials
            if (username == "jeet" && password == "1234")
            {
                return true;
            }

            // Authentication failed
            return false;
        }
    }
}
