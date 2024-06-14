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
    /// Business logic class for handling DIR01 data operations.
    /// </summary>
    public class BLDIR01 : IDataHandlerService<DTODIR01>
    {
        #region Private Fields
        private string _connectionString;
        private Response _objResponse;
        private DBDIR01Context _dbDirectorContext;
        private DIR01 _objDIR01;
        private int _id;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BLDIR01"/> class.
        /// </summary>
        public BLDIR01()
        {
            _dbDirectorContext = new DBDIR01Context();
            _objDIR01 = new DIR01();
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the type of operation (Add/Edit).
        /// </summary>
        public EnmType Type { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all directors.
        /// </summary>
        /// <returns>A response object containing all directors.</returns>
        public Response GetAll()
        {
            DataTable allDirectors = _dbDirectorContext.GetAllDirectors();
            if (allDirectors.Rows.Count == 0) // delete??
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Directors Not Found";
            }
            _objResponse.Data = allDirectors;
            return _objResponse;
        }

        /// <summary>
        /// Adds a new director.
        /// </summary>
        /// <param name="objofDirector">The director object to add.</param>
        /// <returns>A response object indicating the result of the add operation.</returns>
        public Response Add(DIR01 objofDirector)
        {
            return _dbDirectorContext.AddDirectors(objofDirector);
        }

        /// <summary>
        /// Updates an existing director.
        /// </summary>
        /// <param name="objofDirector">The director object to update.</param>
        /// <returns>A response object indicating the result of the update operation.</returns>
        public Response Update(DIR01 objofDirector)
        {
            return _dbDirectorContext.UpdateDirector(objofDirector);
        }

        /// <summary>
        /// Deletes a director by its ID.
        /// </summary>
        /// <param name="id">The ID of the director to delete.</param>
        /// <returns>A response object indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {
            if (_dbDirectorContext.DeleteDirector(id))
            {
                _objResponse.Message = "Director Deleted";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Director is Not Deleted";
            }
            return _objResponse;
        }

        /// <summary>
        /// Prepares the director object for saving by converting the DTO object.
        /// </summary>
        /// <param name="objDto">The DTO object to convert.</param>
        public void PreSave(DTODIR01 objDto)
        {
            _objDIR01 = objDto.Convert<DIR01>();
        }

        /// <summary>
        /// Validates the director object.
        /// </summary>
        /// <returns>A response object indicating the result of the validation.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)
            {
                if (!(_objDIR01.R01F01 > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the director object based on the operation type.
        /// </summary>
        /// <returns>A response object indicating the result of the save operation.</returns>
        public Response Save()
        {
            if (Type == EnmType.A)
            {
                return Add(_objDIR01);
            }
            if (Type == EnmType.E)
            {
                return Update(_objDIR01);
            }
            _objResponse.IsError = true;
            _objResponse.Message = "Internal Error";
            return _objResponse;
        } 
        #endregion
    }
}
