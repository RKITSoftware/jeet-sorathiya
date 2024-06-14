using CPContestRegistration.Models;

namespace CPContestRegistration.BL.Interface
{
    public interface ICommonDataHandlerService<T>
        where T : class
    {
        #region Public Properties

        /// <summary>
        /// Get or set the operation to perform.
        /// </summary>
        public EnmOperation Operation { get; set; }

        #endregion Public Properties

        #region Public Methods
        /// <summary>
        /// Converts the DTO to POCO conversion and initialize the fields which are neccessary.
        /// </summary>
        /// <param name="objDto">DTO cntaining the model information.</param>
        void PreSave(T objDto);

        /// <summary>
        /// Validate the poco model's properties.
        /// </summary>
        /// <returns>Response according to the operation.</returns>
        Response Validation();

        /// <summary>
        /// Performs the add or update operation specified by Operation.
        /// </summary>
        /// <returns>Response according to the operation.</returns>
        Response Save();       

        #endregion Public Methods
    }
}
