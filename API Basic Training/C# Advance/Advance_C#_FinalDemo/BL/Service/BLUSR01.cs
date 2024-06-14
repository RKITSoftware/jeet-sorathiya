using Advance_C__FinalDemo.BL.Interface;
using Advance_C__FinalDemo.DL;
using Advance_C__FinalDemo.Extension;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Advance_C__FinalDemo.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Advance_C__FinalDemo.BL.Service
{
    /// <summary>
    /// Business logic class for handling USR01 data operations.
    /// </summary>
    public class BLUSR01 : IDataHandlerService<DTOUSR01>
    {
        #region Private Fields
        private USR01 _objUSR01;
        private Response _objResponse;
        private IDbConnectionFactory _dbFactory;
        private string _connectionString;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BLUSR01"/> class.
        /// </summary>
        public BLUSR01()
        {
            _objUSR01 = new USR01();
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
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
        /// Checks if a user exists based on username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the user exists, otherwise false.</returns>
        public bool IsExist(string username, string password)
        {
            string encryptedPassword = BLEncryption.GetEncryptPassword(password);
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<USR01>(u =>
                    u.R01F02.Equals(username) &&
                    u.R01F04.Equals(encryptedPassword));
            }
        }

        /// <summary>
        /// Gets a user based on username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The user object.</returns>
        public USR01 GetUser(string username, string password)
        {
            string encryptedPassword = BLEncryption.GetEncryptPassword(password);
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Single<USR01>(u =>
                    u.R01F02.Equals(username) &&
                    u.R01F04.Equals(encryptedPassword));
            }
        }

        /// <summary>
        /// Gets a user based on username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user object.</returns>
        public USR01 GetUser(string username)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Single<USR01>(u => u.R01F02.Equals(username));
            }
        }

        /// <summary>
        /// Gets a user based on ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user object.</returns>
        public USR01 GetUser(int id)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<USR01>(id);
            }
        }

        /// <summary>
        /// Retrieves all user data.
        /// </summary>
        /// <returns>A response object containing all user data.</returns>
        public Response GetData()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    List<USR01> users = db.Select<USR01>();
                    _objResponse.Data = users;
                }
                return _objResponse;
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                throw new Exception($"Error retrieving USR01 data: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="newUser">The user object to add.</param>
        /// <returns>A response object indicating the result of the add operation.</returns>
        public Response Add(USR01 newUser)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to insert a new user into the USR01 table
                    db.Insert(newUser);
                }
                _objResponse.Message = "Data Added";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Data Not Added";
                // Handle and rethrow exception with additional information
                throw new Exception(ex.Message);
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="newUser">The user object to update.</param>
        /// <returns>A response object indicating the result of the update operation.</returns>
        public Response Update(USR01 newUser)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to update an existing user in the USR01 table
                    db.Update(newUser);
                }
                _objResponse.Message = "Data Is Updated";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Internal Error";
                throw new Exception(ex.Message);
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the user was deleted, otherwise false.</returns>
        public bool Delete(int id)
        {
            bool isResponse = true;
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to delete a user from the USR01 table by ID
                    db.DeleteById<USR01>(id);
                }
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                isResponse = false;
                throw new Exception(ex.Message);
            }
            return isResponse;
        }

        /// <summary>
        /// Prepares the user object for saving by converting the DTO object.
        /// </summary>
        /// <param name="objDto">The DTO object to convert.</param>
        public void PreSave(DTOUSR01 objDto)
        {
            _objUSR01 = objDto.Convert<USR01>();
            _objUSR01.R01F04 = BLEncryption.GetEncryptPassword(_objUSR01.R01F04);
        }

        /// <summary>
        /// Validates the user object.
        /// </summary>
        /// <returns>A response object indicating the result of the validation.</returns>
        public Response Validation()
        {
            return _objResponse;
        }

        /// <summary>
        /// Saves the user object based on the operation type.
        /// </summary>
        /// <returns>A response object indicating the result of the save operation.</returns>
        public Response Save()
        {
            if (Type == EnmType.A)
            {
                return Add(_objUSR01);
            }
            if (Type == EnmType.E)
            {
                return Update(_objUSR01);
            }
            _objResponse.IsError = true;
            _objResponse.Message = "Internal Error";
            return _objResponse;
        } 
        #endregion
    }
}
