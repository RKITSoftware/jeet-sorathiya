using Advance_C__FinalDemo.BL.Interface;
using Advance_C__FinalDemo.DL;
using Advance_C__FinalDemo.Extension;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Advance_C__FinalDemo.Models.POCO;
using MySql.Data.MySqlClient;
using ServiceStack;
using System;
using System.Data;
using System.Web;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// Business logic class for managing CRUD operations on the DIR01 table
    /// </summary>
    public class BLDirector : IDataHandlerService<DTODIR01>
    {

        private string _connectionString;
        private Response _objResponse;
        private DBDirectorContext _dbDirectorContext;
        private DIR01 _objDIR01;
        private int _id;

        /// <summary>
        /// Initializes a new instance of the BLDirector class.
        /// </summary>
        public BLDirector()
        {
            _dbDirectorContext = new DBDirectorContext();
            _objDIR01 = new DIR01();
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        }
        public EnmType Type { get; set; }

      
        public Response GetAll()
        {
            DataTable allDirectors = _dbDirectorContext.GetAllDirectors();
            if(allDirectors.Rows.Count == 0)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Directors Not Found";
            }
            _objResponse.Data = allDirectors;
            return _objResponse;
        }

  
        public Response Add(DIR01 objofDirector)
        {           
            return _dbDirectorContext.AddDirectors(objofDirector);
        }

      
        public Response Update(int id, DIR01 objofDirector)
        {
            return _dbDirectorContext.UpdateDirector(id, objofDirector);
        }

        public Response Delete(int id)
        {
           if(_dbDirectorContext.DeleteDirector(id))
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
        /// Prepares the object for saving
        /// </summary>
        /// <param name="id">The ID of the object, if available.</param>
        /// <param name="objDto">The DTODIR01 object containing data to be converted and saved.</param>
        public void PreSave(DTODIR01 objDto, int id = 0)
        {
            _objDIR01 = objDto.Convert<DIR01>();
            if (Type == EnmType.E)
            {
                if (id > 0)
                {
                    _id = (int)id;
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
        /// Saves the object based on the type (add or update)
        /// </summary>
        /// <returns>A Response object indicating the outcome of the save operation.</returns>
        public Response Save()
        {
            if (Type == EnmType.A)
            {
                return Add(_objDIR01);
            }
            if(Type == EnmType.E)
            {
                return Update(_id, _objDIR01);
            }
            _objResponse.IsError = true;
            _objResponse.Message = "Internal Error";
            return _objResponse;
        }
    }
}
