using Advance_C__FinalDemo.BL.Interface;
using Advance_C__FinalDemo.Extension;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Advance_C__FinalDemo.Models.POCO;
using MySql.Data.MySqlClient;
using System;
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
        private Response _objResponse;
        private CAT01 _objCAT01;
        private int _id;

        public EnmType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the BLCategory class.
        /// </summary>
        public BLCategory()
        {
            _objResponse = new Response();
            _objCAT01 = new CAT01();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        }

        /// <summary>
        /// Retrieves all categories from the CAT01 table
        /// </summary>
        /// <returns>DataTable containing all categories</returns>
        public DataTable GetAll()
        {
            DataTable allCategorys = new DataTable();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM CAT01;", conn))
                {
                    // Execute SQL command and populate the DataTable with results
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        allCategorys.Load(reader);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { conn.Close(); }
            return allCategorys;
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="objofCategory">The category object to be added.</param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        public Response Add(CAT01 objofCategory)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO CAT01 (T01F02) VALUES (@Category)";
                    cmd.Parameters.AddWithValue("@Category", objofCategory.T01F02);
                    conn.Open();
                    // Execute SQL command to add a new category
                    cmd.ExecuteNonQuery();
                }
                _objResponse.Message = "Data Added";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="id">The ID of the category to be updated.</param>
        /// <param name="objofCategory">The category object containing the updated information.</param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        public Response Update(int id, CAT01 objofCategory)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE CAT01 " +
                                       "SET T01F02 = @CategoryName " +
                                       "WHERE T01F01 = @ID";
                    cmd.Parameters.AddWithValue("@CategoryName", objofCategory.T01F02);
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    // Execute SQL command to update an existing category
                    cmd.ExecuteNonQuery();
                }
                _objResponse.Message = "Data Updated";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a category from the CAT01 table by ID
        /// </summary>
        /// <param name="id">Category ID to be deleted</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Delete(int id)
        {
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM CAT01 " +
                                       "WHERE T01F01 = @ID";

                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    // Execute SQL command to delete a category
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                isResponse = false;
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return isResponse;
        }

        /// <summary>
        /// Prepares the object for saving
        /// </summary>
        /// <param name="id">The ID of the object, if available.</param>
        /// <param name="objDto">The DTOCAT01 object </param>
        public void PreSave(int? id, DTOCAT01 objDto)
        {
            _objCAT01 = objDto.Convert<CAT01>();
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