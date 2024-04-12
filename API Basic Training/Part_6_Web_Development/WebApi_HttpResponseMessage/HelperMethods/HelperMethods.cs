namespace WebApi_HttpResponseMessage.Controllers
{
    /// <summary>
    /// Contains helper methods for the web API.
    /// </summary>
    public class HelperMethods
    {
        /// <summary>
        /// Counter for generating unique employee IDs.
        /// </summary>
        public static int employeeIdCounter = 1;

        /// <summary>
        /// Generates a new unique employee ID.
        /// </summary>
        /// <returns>A new employee ID.</returns>
        public static int NewEmpID()
        {
            return employeeIdCounter++;
        }
    }
}