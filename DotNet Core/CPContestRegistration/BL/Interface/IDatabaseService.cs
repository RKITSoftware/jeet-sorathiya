using System.Data;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for interacting with a database service
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Executes a MySQL query and returns the result as a DataTable
        /// </summary>
        /// <param name="query">The MySQL query to execute</param>
        /// <returns>A DataTable containing the result of the query</returns>
        DataTable ExecuteQuery(string query);
    }
}
