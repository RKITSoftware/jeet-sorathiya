using Advance_C__FinalDemo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// Business logic class for managing CRUD operations on the DIR01 table
    /// </summary>
    public class BLDirector
    {
        // Connection string for the database
        private readonly string _connectionString = "Server=127.0.0.1;Database=moviehub_jeet;User ID=Admin;Password=gs@123;";

        /// <summary>
        /// Retrieves all directors from the DIR01 table
        /// </summary>
        /// <returns>DataTable containing all directors</returns>
        public DataTable GetAll()
        {
            DataTable allCategorys = new DataTable();
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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
        /// Adds a new director to the DIR01 table.
        /// </summary>
        /// <param name="objofDirector">DIR01 object representing the director to be added</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Add(DIR01 objofDirector)
        {
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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
        /// Updates an existing director in the DIR01 table.
        /// </summary>
        /// <param name="id">Director ID</param>
        /// <param name="objofDirector">DIR01 object representing the updated director data</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Update(int id, DIR01 objofDirector)
        {
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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
        /// Deletes a director from the DIR01 table by ID.
        /// </summary>
        /// <param name="id">Director ID to be deleted</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Delete(int id)
        {
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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

    }
}
