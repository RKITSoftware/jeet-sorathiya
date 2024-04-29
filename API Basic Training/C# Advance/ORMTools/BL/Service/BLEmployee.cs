using ORMTools.BL.Interface;
using ORMTools.Extension;
using ORMTools.Models;
using ORMTools.Models.DTO;
using ORMTools.Models.Enum;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Web;

namespace ORMTools.BL
{
    /// <summary>
    /// Business logic class for managing EMP01 (Employee) data.
    /// </summary>
    public class BLEmployee : IDataHandlerService<DTOEMP01>
    {
        private EMP01 _objEMP01;
        private int _id;
        // Retrieve IDbConnectionFactory from the application context
        private readonly IDbConnectionFactory _dbFactory;

        private Response _objResponse;
        public EnmType Type { get; set; }

        /// <summary>
        /// BLEmployee Constructor
        /// </summary>
        public BLEmployee()
        {
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>List of employees</returns>
        public List<EMP01> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                var employees = db.Select<EMP01>();

                return employees;
            }
        }

        /// <summary>
        /// Retrieves an employee by ID from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee with the specified ID</returns>
        public EMP01 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                var employee = db.SingleById<EMP01>(id);
                return employee;
            }
        }

        /// <summary>
        /// Checks whether an employee with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>True if the employee exists, otherwise false</returns>
        private bool IsEMP01Exist(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<EMP01>(id);
            }
        }

        /// <summary>
        /// Deletes an employee by ID from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        public Response Delete(int id)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.DeleteById<EMP01>(id);
                }
                _objResponse.Message = "Data Deleted";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;

        }

        /// <summary>
        /// Performs actions before saving the employee data.
        /// </summary>
        /// <param name="objDto">DTO object containing employee data</param>
        public void PreSave(DTOEMP01 objDto)
        {
            _objEMP01 = objDto.Convert<EMP01>();
            if (Type == EnmType.E)
            {
                if (objDto.P01F01 > 0)
                {
                    _id = objDto.P01F01;
                }
            }
        }

        /// <summary>
        /// Performs validation before saving the employee data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
                else
                {
                    bool isEMP01 = IsEMP01Exist(_id);
                    if (!isEMP01)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "User Not Found";
                    }
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the employee data to the database.
        /// </summary>
        /// <returns>Response object indicating success or failure of saving operation</returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    if (Type == EnmType.A)
                    {
                        db.Insert(_objEMP01);
                        _objResponse.Message = "Data Added";
                    }
                    if (Type == EnmType.E)
                    {
                        db.Update(_objEMP01);
                        _objResponse.Message = "Data Updated";
                    }
                }

            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }
    }
}