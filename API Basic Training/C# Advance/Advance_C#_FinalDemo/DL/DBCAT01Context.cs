using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;

namespace Advance_C__FinalDemo.DL
{
    /// <summary>
    /// Context class for performing database operations related to categories.
    /// </summary>
    public class DBCAT01Context
    {
        #region Private Fields
        private Response _objResponse;
        private string _connectionString;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the DBCAT01Context class.
        /// </summary>
        public DBCAT01Context()
        {
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>A DataTable containing all categories.</returns>
        public DataTable GetAllCategories()
        {
            DataTable allCategories = new DataTable();
            string query = @"SELECT 
                                    T01F01, 
                                    T01F02 
                              FROM CAT01;";
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Execute SQL command and populate the DataTable with results
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        allCategories.Load(reader);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { conn.Close(); }
            return allCategories;
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="objofCategory">The category object to be added.</param>
        /// <returns>A response indicating the result of the add operation.</returns>
        public Response AddCategory(CAT01 objofCategory)
        {
            string query = string.Format(@"INSERT INTO CAT01 
                                                (T01F02)  
                                                    VALUES  
                                                '{0}';", objofCategory.T01F02);
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
        /// <param name="objofCategory">The category object with updated data.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        public Response UpdateCategory(CAT01 objofCategory)
        {
            string query = string.Format(@"UPDATE CAT01
                                            SET T01F02 = '{0}' 
                                            WHERE T01F01 = {1}", objofCategory.T01F02, objofCategory.T01F01);
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="id">The ID of the category to be deleted.</param>
        /// <returns>True if the category was deleted successfully, otherwise false.</returns>
        public bool DeleteCategory(int id)
        {
            string query = string.Format(@"DELETE FROM CAT01 
                                            WHERE T01F01 = {0}", id);
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
        #endregion
    }
}
