using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;
using CPContestRegistration.Models.POCO;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for managing participation in contests.
    /// </summary>
    public interface IPAR01 : ICommonDataHandlerService<DTOPAR01>
    {

        #region Public Methods
        /// <summary>
        /// Deletes a participation record by its id
        /// </summary>
        /// <param name="id">The id of the participation record to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        Response Delete(int id);

        /// <summary>
        /// Retrieves all participation records.
        /// </summary>
        /// <returns>A response containing a list of all participation records.</returns>
        Response SelectAll();

        /// <summary>
        /// Retrieves a participation record by its id
        /// </summary>
        /// <param name="id">The id of the participation record to retrieve.</param>
        /// <returns>A response containing the participation record with the specified id</returns>
        Response SelectPk(int id); 
        #endregion
    }
}