using CPContestRegistration.Models;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    /// <summary>
    /// Interface for managing participation in contests.
    /// </summary>
    public interface IParticipateManagement
    {
        /// <summary>
        /// Adds a new participation 
        /// </summary>
        /// <param name="objPAR01">The participation  object to add</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        bool Add(PAR01 objPAR01);

        /// <summary>
        /// Deletes a participation based on ID
        /// </summary>
        /// <param name="id">The ID of the participation to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Retrieves all participation
        /// </summary>
        /// <returns>A DataTable containing all participation </returns>
        DataTable SelectAll();

        /// <summary>
        /// Retrieves a participation  based on ID
        /// </summary>
        /// <param name="id">The ID of the participation to retrieve</param>
        /// <returns>The participation  corresponding to the given ID, or null if not found</returns>
        List<PAR01> SelectPk(int id);

        /// <summary>
        /// Updates an existing participation
        /// </summary>
        /// <param name="objPAR01">The participation object to update</param>
        /// <returns>True if the operation was successful, otherwise false</returns>k
        bool Update(PAR01 objPAR01);
    }
}