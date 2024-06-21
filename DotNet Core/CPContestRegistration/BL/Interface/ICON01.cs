using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for managing contest-related operations.
    /// </summary>
    public interface ICON01 : ICommonDataHandlerService<DTOCON01>
    {
        #region Public Methods
        /// <summary>
        /// Deletes a contest entry by its is
        /// </summary>
        /// <param name="id">The id of the contest to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        Response Delete(int id);

        /// <summary>
        /// Retrieves all contest entries.
        /// </summary>
        /// <returns>A response containing a list of all contest.</returns>
        Response SelectAll(); ///get data

        /// <summary>
        /// Retrieves a contest entry by id.
        /// </summary>
        /// <param name="id">The id of the contest</param>
        /// <returns>A response containing the contest</returns>
        Response SelectPk(int id); 
        #endregion
    }
}