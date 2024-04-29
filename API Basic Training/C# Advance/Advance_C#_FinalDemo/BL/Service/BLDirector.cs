using Advance_C__FinalDemo.BL.Interface;
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
        private DIR01 _objDIR01;
        private int _id;

        /// <summary>
        /// Initializes a new instance of the BLDirector class.
        /// </summary>
        public BLDirector()
        {
            _objDIR01 = new DIR01();
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        }
        public EnmType Type { get; set; }

        /// <summary>
        /// Retrieves all directors from the DIR01 table
        /// </summary>
        /// <returns>DataTable containing all directors</returns>
        public DataTable GetAll()
        {
            DataTable allCategorys = new DataTable();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM DIR01;", conn))
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
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="objofDirector">The director object to be added.</param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        public Response Add(DIR01 objofDirector)
        {           
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO DIR01 (R01F02) VALUES (@Director)";
                    cmd.Parameters.AddWithValue("@Director", objofDirector.R01F02);
                    conn.Open();
                    // Execute SQL command to add a new director
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
        /// Updates an existing director in the database.
        /// </summary>
        /// <param name="id">The ID of the director to be updated.</param>
        /// <param name="objofDirector">The director object containing the updated information.</param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        public Response Update(int id, DIR01 objofDirector)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE DIR01 " +
                                       "SET R01F02 = @DirectorName " +
                                       "WHERE R01F01 = @ID";
                    cmd.Parameters.AddWithValue("@DirectorName", objofDirector.R01F02);
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    // Execute SQL command to update an existing director
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
        /// Deletes a director from the DIR01 table by ID.
        /// </summary>
        /// <param name="id">Director ID to be deleted</param>
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
                    cmd.CommandText = "DELETE FROM DIR01 " +
                                       "WHERE R01F01 = @ID";

                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    // Execute SQL command to delete a director
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
        /// <param name="objDto">The DTODIR01 object containing data to be converted and saved.</param>
        public void PreSave(int? id, DTODIR01 objDto)
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
