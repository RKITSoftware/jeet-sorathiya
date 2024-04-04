using CPContestRegistration.Models;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for managing contest-related operations.
    /// </summary>
    public interface IContestManagement
    {
        /// <summary>
        /// Adds a new contest
        /// </summary>
        /// <param name="objCON01">The contest object to add</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        bool Add(CON01 objCON01);

        /// <summary>
        /// Deletes a contest based on ID
        /// </summary>
        /// <param name="id">The ID of the contest to delete.</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        bool Delete(int id);

        /// <summary>
        /// Retrieves all contest as a DataTable
        /// </summary>
        /// <returns>A DataTable containing all contest </returns>
        DataTable SelectAll();

        /// <summary>
        /// Retrieves a contest based on ID
        /// </summary>
        /// <param name="id">The ID of the contest entry to retrieve.</param>
        /// <returns>The contest corresponding ID, or null if not found</returns>
        CON01 SelectPk(int id);

        /// <summary>
        /// Updates an existing contest
        /// </summary>
        /// <param name="objCON01">The contest object to update</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        bool Update(CON01 objCON01);
    }
}