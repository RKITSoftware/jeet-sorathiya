using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Advance_C__FinalDemo.DL
{
    public class DBCategoryContext
    {
        private Response _objResponse;
        private string _connectionString;

        public DBCategoryContext()
        {
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;

        }
        public DataTable GetAllCategories()
        {
            DataTable allCategories = new DataTable();
            string query = @"SELECT * FROM CAT01;"; //??
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

        public Response AddCategory(CAT01 objofCategory)
        {
            string query = string.Format(@"INSERT INTO CAT01 
                                                (T01F02)  
                                                    VALUES  
                                                (@0);", objofCategory.T01F02);
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

        public Response UpdateCategory(int id, CAT01 objofCategory)
        {
            string query = string.Format(@"UPDATE CAT01
                                            SET T01F02 = @0 
                                            WHERE T01F01 = @1", objofCategory.T01F02, id);
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

        public bool DeleteCategory(int id)
        {
            string query = string.Format(@"DELETE FROM CAT01 
                                            WHERE T01F01 = @0", id);
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query,conn))
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
    }
}