using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;
using CPContestRegistration.Models.POCO;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for managing user-related operations.
    /// </summary>
    public interface IUSE01 : ICommonDataHandlerService<DTOUSE01>
    {
        #region Public Methods
        /// <summary>
        /// Deletes a user record by its id.
        /// </summary>
        /// <param name="id">The id of the user record to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        Response Delete(int id);

        /// <summary>
        /// Retrieves all user records.
        /// </summary>
        /// <param name="isInternalCall">Indicates whether the call is internal.</param>
        /// <returns>A response containing a list of all user records.</returns>
        Response SelectAll(bool isInternalCall = false);

        /// <summary>
        /// Retrieves a user record by its id.
        /// </summary>
        /// <param name="id">The id of the user record to retrieve.</param>
        /// <returns>A response containing the user record with the specified id.</returns>
        Response SelectPk(int id); 
        #endregion
    }
}