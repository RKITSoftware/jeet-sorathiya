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
    /// Business logic class for managing CRUD operations on the CAT01 table
    /// </summary>
    public class BLCategory : IDataHandlerService<DTOCAT01>
    {
        private string _connectionString;
        private DBCategoryContext _dbCategoryContext;
        private Response _objResponse;
        private CAT01 _objCAT01;
        private int _id;

        public EnmType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the BLCategory class.
        /// </summary>
        public BLCategory()
        {
            _dbCategoryContext = new DBCategoryContext();
            _objResponse = new Response();
            _objCAT01 = new CAT01();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        }
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

        public Response Add(CAT01 objofCategory)
        {
            return _dbCategoryContext.AddCategory(objofCategory);
        }

        public Response Update(int id, CAT01 objofCategory)
        {
            return _dbCategoryContext.UpdateCategory(id, objofCategory);
        }

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
        /// Prepares the object for saving
        /// </summary>
        /// <param name="id">The ID of the object, if available.</param>
        /// <param name="objDto">The DTOCAT01 object </param>
        public void PreSave(DTOCAT01 objDto, int id = 0)
        {
            _objCAT01 = objDto.Convert<CAT01>();
            if (Type == EnmType.E)
            {
                if (id > 0)
                {
                    _id = id;
                }
            }
        }

        /// <summary>
        /// Validates the object before saving
        /// </summary>
        /// <returns>A Response object indicating any validation errors.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the object based on the type
        /// </summary>
        /// <returns>A Response object indicating the outcome of the save operation.</returns>
        public Response Save()
        {
            if (Type == EnmType.A)
            {
                return Add(_objCAT01);
            }
            if (Type == EnmType.E)
            {
                return Update(_id, _objCAT01);
            }
            _objResponse.IsError = true;
            _objResponse.Message = "Internal Error";
            return _objResponse;
        }
    }
}