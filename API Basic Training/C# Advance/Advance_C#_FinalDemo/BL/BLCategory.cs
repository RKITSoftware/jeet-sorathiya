using Advance_C__FinalDemo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// Business logic class for managing CRUD operations on the CAT01 table
    /// </summary>
    public class BLCategory
    {
        // Connection string for the database
        private readonly string _connectionString = "Server=127.0.0.1;Database=moviehub_jeet;User ID=Admin;Password=gs@123;";

        /// <summary>
        /// Retrieves all categories from the CAT01 table
        /// </summary>
        /// <returns>DataTable containing all categories</returns>
        public DataTable GetAll()
        {
            DataTable allCategorys = new DataTable();
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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
        /// Adds a new category to the CAT01 table
        /// </summary>
        /// <param name="objofCategory">CAT01 object representing the category to be added</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Add(CAT01 objofCategory)
        {
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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
        /// Updates an existing category in the CAT01 table
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <param name="objofCategory">CAT01 object representing the updated category data</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Update(int id, CAT01 objofCategory)
        {
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(this._connectionString);
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
        /// Deletes a category from the CAT01 table by ID
        /// </summary>
        /// <param name="id">Category ID to be deleted</param>
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

    }
}