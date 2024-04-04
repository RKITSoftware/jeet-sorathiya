using CPContestRegistration.BL.Interface;
using MySql.Data.MySqlClient;
using System.Data;

namespace CPContestRegistration.BL.Service
{
    /// <summary>
    /// Service class for interacting with a database.
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Constructor for DatabaseService.
        /// </summary>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public DatabaseService(IConfiguration configuration, ILoggerService loggerService)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _loggerService = loggerService;
        }

        /// <summary>
        /// Executes a MySQL query and returns the result as a DataTable
        /// </summary>
        /// <param name="query">The MySQL query to execute</param>
        /// <returns>A DataTable containing the result of the query</returns>
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return null;
            }
            
            
        }
    }
}
