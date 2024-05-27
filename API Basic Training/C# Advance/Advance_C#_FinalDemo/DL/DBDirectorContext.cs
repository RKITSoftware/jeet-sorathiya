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
    public class DBDirectorContext
    {
        private Response _objResponse;
        private string _connectionString;

        public DBDirectorContext()
        {
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;

        }
        public DataTable GetAllDirectors()
        {
            string query = string.Format(@"SELECT * FROM DIR01;");
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

        public Response AddDirectors(DIR01 objofDirector)
        {
            string query = string.Format(@"INSERT INTO DIR01 
                                                    (R01F02) 
                                                        VALUES 
                                                    (@0)", objofDirector.R01F02);
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query,conn))
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

        public Response UpdateDirector(int id, DIR01 objofDirector)
        {
            string query = string.Format(@"UPDATE DIR01 
                                            SET R01F02 = @0 
                                            WHERE R01F01 = @1", objofDirector.R01F02, id);
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query,conn))
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

        public bool DeleteDirector(int id)
        {
            string query = string.Format(@"DELETE FROM DIR01
                                            WHERE R01F01 = @0", id);
            bool isResponse = true;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query,conn))
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
    }
}