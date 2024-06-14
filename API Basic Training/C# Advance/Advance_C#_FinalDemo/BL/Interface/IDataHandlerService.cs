﻿using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.Enum;

namespace Advance_C__FinalDemo.BL.Interface
{
    /// <summary>
    /// Interface for handling data operations of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of data to handle.</typeparam>
    public interface IDataHandlerService<T> where T : class
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the type of opration (Edit, Add).
        /// </summary>
        EnmType Type { get; set; } 
        #endregion

        #region Public Methods
        /// <summary>
        /// Performs pre-save operations on the data object before saving.
        /// </summary>
        /// <param name="objDto">The data object to be saved.</param>
        void PreSave(T objDto);

        /// <summary>
        /// Validates the data before saving.
        /// </summary>
        /// <returns>A response indicating whether the validation was successful.</returns>
        Response Validation();

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>A response indicating the result of the save operation.</returns>
        Response Save(); 
        #endregion
    }
}