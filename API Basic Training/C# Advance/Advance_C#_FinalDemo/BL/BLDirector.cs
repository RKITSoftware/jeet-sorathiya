using Advance_C__FinalDemo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Advance_C__FinalDemo.BL
{
    public class BLDirector
    {
        private readonly string _connectionString = "Server=127.0.0.1;Database=moviehub_jeet;User ID=Admin;Password=gs@123;";

        public DataTable GetAll()
        {
            DataTable allCategorys = new DataTable();
            MySqlConnection conn = new MySqlConnection(this._connectionString);
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM DIR01;", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        allCategorys.Load(reader);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return allCategorys;
        }

        public bool Add(DIR01 objofDirector)
        {
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { conn.Close(); }
            return true;
        }

        public bool Update(int id, DIR01 objofDirector)
        {
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { conn.Close(); }
            return true;
        }

        public bool Delete(int id)
        {
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally { conn.Close(); }
            return true;
        }

    }
}