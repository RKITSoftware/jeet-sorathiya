using CPContestRegistration.Models;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for managing user-related operations.
    /// </summary>
    public interface IUserManagement
    {
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="objUSE01">The user  object to add</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        bool Add(USE01 objUSE01);

        /// <summary>
        /// Deletes a user based on its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Retrieves all user 
        /// </summary>
        /// <param name="isInternalCall">Optional parameter indicating if the call is internal.</param>
        /// <returns>A DataTable containing all user entries.</returns>
        DataTable SelectAll(bool isInternalCall = false);

        /// <summary>
        /// Retrieves a user  based on ID
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns>The user  corresponding to the given ID, or null if not found.</returns>
        USE01 SelectPk(int id);

        /// <summary>
        /// Updates an existing user .
        /// </summary>
        /// <param name="objUSE01">The user  object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(USE01 objUSE01);
    }
}