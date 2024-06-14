using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;

namespace Advance_C__FinalDemo.DL
{
    /// <summary>
    /// Context class for performing database operations related to directors.
    /// </summary>
    public class DBDIR01Context
    {
        #region Private Fields
        private Response _objResponse;
        private string _connectionString;
        #endregion

        #region Contructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DBDIR01Context"/> class.
        /// </summary>
        public DBDIR01Context()
        {
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all directors from the database.
        /// </summary>
        /// <returns>A DataTable containing all directors.</returns>
        public DataTable GetAllDirectors()
        {
            string query = string.Format(@"SELECT 
                                                R01F01, 
                                                R01F02 
                                            FROM DIR01;");
            DataTable allDirectors = new DataTable();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Execute SQL command and populate the DataTable with results
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        allDirectors.Load(reader);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { conn.Close(); }
            return allDirectors;
        }

        /// <summary>
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="objofDirector">The director object to be added.</param>
        /// <returns>A response indicating the result of the add operation.</returns>
        public Response AddDirectors(DIR01 objofDirector)
        {
            string query = string.Format(@"INSERT INTO DIR01 
                                                    (R01F02) 
                                                        VALUES 
                                                    '{0}';", objofDirector.R01F02);
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
        /// <param name="objofDirector">The director object with updated data.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        public Response UpdateDirector(DIR01 objofDirector)
        {
            string query = string.Format(@"UPDATE DIR01 
                                            SET R01F02 = '{0}' 
                                            WHERE R01F01 = {1};", objofDirector.R01F02, objofDirector.R01F01);
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
        /// Deletes a director from the database.
        /// </summary>
        /// <param name="id">The ID of the director to be deleted.</param>
        /// <returns>True if the director was deleted successfully, otherwise false.</returns>
        public bool DeleteDirector(int id)
        {
            string query = string.Format(@"DELETE FROM DIR01
                                            WHERE R01F01 = {0}", id);
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
        #endregion
    }
}
