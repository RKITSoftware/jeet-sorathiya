using CPContestRegistration.BL.Interface;
using NLog;

namespace CPContestRegistration.BL.Service
{
    /// <summary>
    /// Service class for logging errors using NLog
    /// </summary>
    public class LoggerService : ILoggerService
    {
        #region Private Fields
        private readonly Logger _logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for LoggerService
        /// </summary>
        public LoggerService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">The error message to log</param>
        public void ErrorLog(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// Logs information about an exception
        /// </summary>
        /// <param name="exception">The exception to log</param>
        public void ErrorLog(Exception exception)
        {
            _logger.Error(exception);
        } 
        #endregion
    }
}
