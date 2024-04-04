namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for logging errors
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">The error message to log</param>
        void ErrorLog(string message);

        /// <summary>
        /// Logs information about an exception
        /// </summary>
        /// <param name="exception">The exception to log</param>
        void ErrorLog(Exception exception);
    }
}