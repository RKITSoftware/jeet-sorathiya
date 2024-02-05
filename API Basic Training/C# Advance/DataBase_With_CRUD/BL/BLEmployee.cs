using DataBase_With_CRUD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;

namespace DataBase_With_CRUD.BL
{
    /// <summary>
    /// Business logic class for handling CRUD operations on EMP01 table
    /// </summary>
    public class BLEmployee
    {
        private readonly string _connectionString = "Server=127.0.0.1;Database=employee_jeet;User ID=Admin;Password=gs@123;";

        #region GetAll
        /// <summary>
        /// Retrieves all employees from the EMP01 table
        /// </summary>
        /// <returns>List of EMP01 objects representing employees</returns>

        public List<EMP01> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            List<EMP01> employeeList = new List<EMP01>();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM EMP01;", connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeList.Add(new EMP01()
                            {
                                P01F01 = (int)reader[0],
                                P01F02 = (string)reader[1],
                                P01F03 = (string)reader[2],
                                P01F04 = Convert.ToBoolean(reader[3]),

                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }

            return employeeList;
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds a new employee to the EMP01 table
        /// </summary>
        /// <param name="employee">Employee data to be added</param>
        /// <returns>HTTP response</returns>

        public HttpResponseMessage Add(EMP01 employee)
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO EMP01 (P01F02, P01F03, P01F04) VALUES (@Name, @Role, @IsActive)";

                    cmd.Parameters.AddWithValue("@Name", employee.P01F02);
                    cmd.Parameters.AddWithValue("@Role", employee.P01F03);
                    cmd.Parameters.AddWithValue("@IsActive", employee.P01F04);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
            finally { connection.Close(); }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Data Added")
            };
        }
        #endregion

        #region Update

        /// <summary>
        /// Updates an existing employee in the EMP01 table
        /// </summary>
        /// <param name="Id">Employee ID to be updated</param>
        /// <param name="employee">Updated employee data</param>
        /// <returns>HTTP response</returns>
        public HttpResponseMessage Update(int Id, EMP01 employee)
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE EMP01 " +
                                        "SET P01F02 = @Name, " +
                                        "P01F03 = @Role, " +
                                        "P01F04 = @IsActive " +
                                        "WHERE P01F01 = @Id ";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Name", employee.P01F02);
                    cmd.Parameters.AddWithValue("@Role", employee.P01F03);
                    cmd.Parameters.AddWithValue("@IsActive", employee.P01F04);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Data Update")
            };
        }
        #endregion

        #region Delete

        /// <summary>
        /// Deletes an employee from the EMP01 table by ID
        /// </summary>
        /// <param name="empid">Employee ID to be deleted</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Delete(int empid)
        {
            MySqlConnection connection = new MySqlConnection(this._connectionString);
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM EMP01 " +
                                        "WHERE P01F01 = @Id";

                    cmd.Parameters.AddWithValue("@Id", empid);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Data Delete")
            };
        }
        #endregion
    }
}
