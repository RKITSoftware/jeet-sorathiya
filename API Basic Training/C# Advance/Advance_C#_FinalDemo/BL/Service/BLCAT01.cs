using Advance_C__FinalDemo.BL.Interface;
using Advance_C__FinalDemo.DL;
using Advance_C__FinalDemo.Extension;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Advance_C__FinalDemo.Models.POCO;
using System.Data;
using System.Web;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// Business logic class for handling CAT01 data operations.
    /// </summary>
    public class BLCAT01 : IDataHandlerService<DTOCAT01>
    {
        #region Private Fields
        private string _connectionString;
        private DBCAT01Context _dbCategoryContext;
        private Response _objResponse;
        private CAT01 _objCAT01;
        private int _id;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the type of operation (Add/Edit).
        /// </summary>
        public EnmType Type { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BLCAT01"/> class.
        /// </summary>
        public BLCAT01()
        {
            _dbCategoryContext = new DBCAT01Context();
            _objResponse = new Response();
            _objCAT01 = new CAT01();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        } 
        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A response object containing all categories.</returns>
        public Response GetAll()
        {
            DataTable allCategories = _dbCategoryContext.GetAllCategories();
            if (allCategories.Rows.Count == 0)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Categories Available";
            }
            _objResponse.Data = allCategories;
            return _objResponse;
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="objofCategory">The category object to add.</param>
        /// <returns>A response object indicating the result of the add operation.</returns>
        public Response Add(CAT01 objofCategory)
        {
            return _dbCategoryContext.AddCategory(objofCategory);
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="objofCategory">The category object to update.</param>
        /// <returns>A response object indicating the result of the update operation.</returns>
        public Response Update(CAT01 objofCategory)
        {
            return _dbCategoryContext.UpdateCategory(objofCategory);
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>A response object indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {
            if (_dbCategoryContext.DeleteCategory(id))
            {
                _objResponse.Message = "Category Deleted";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Category Not Deleted";
            }
            return _objResponse;
        }

        /// <summary>
        /// Prepares the category object for saving by converting the DTO object.
        /// </summary>
        /// <param name="objDto">The DTO object to convert.</param>
        public void PreSave(DTOCAT01 objDto)
        {
            _objCAT01 = objDto.Convert<CAT01>();
        }

        /// <summary>
        /// Validates the category object.
        /// </summary>
        /// <returns>A response object indicating the result of the validation.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)
            {
                if (!(_objCAT01.T01F01 > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the category object based on the operation type.
        /// </summary>
        /// <returns>A response object indicating the result of the save operation.</returns>
        public Response Save()
        {
            if (Type == EnmType.A)
            {
                return Add(_objCAT01);
            }
            if (Type == EnmType.E)
            {
                return Update(_objCAT01);
            }
            _objResponse.IsError = true;
            _objResponse.Message = "Internal Error";
            return _objResponse;
        } 
        #endregion
    }
}
