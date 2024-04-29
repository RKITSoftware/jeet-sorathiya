using DataBase_With_CRUD.BL.Interface;
using DataBase_With_CRUD.Extension;
using DataBase_With_CRUD.Models;
using DataBase_With_CRUD.Models.DTO;
using DataBase_With_CRUD.Models.Enum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
namespace DataBase_With_CRUD.BL
{
    /// <summary>
    /// Business logic class for handling CRUD operations on EMP01 table
    /// </summary>
    public class BLEmployee : IDataHandlerService<DTOEMP01>
    {
        private string _connectionString;
        private EMP01 _objEMP01;
        private Response _objResponse;
        private int _id;
        public EnmType Type { get; set; }

        /// <summary>
        /// Constructor for the BLEmployee class.
        /// </summary>
        public BLEmployee()
        {
            _objResponse = new Response();
            _connectionString = HttpContext.Current.Application["ConnectionString"] as string;
        }
        #region GetAll
        /// <summary>
        /// Retrieves all employees from the EMP01 table
        /// </summary>
        /// <returns>List of EMP01 objects representing employees</returns>
        public List<EMP01> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
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
        public Response Add(EMP01 employee)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
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
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                return _objResponse;
            }
            finally { connection.Close(); }
            _objResponse.Message = "Data Added";
            return _objResponse;
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates an existing employee in the EMP01 table
        /// </summary>
        /// <param name="Id">Employee ID to be updated</param>
        /// <param name="employee">Updated employee data</param>
        /// <returns>HTTP response</returns>
        public Response Update(int Id, EMP01 employee)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
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
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                return _objResponse;
            }
            finally { connection.Close(); }

            _objResponse.Message = "Data Update";
            return _objResponse;
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
            MySqlConnection connection = new MySqlConnection(_connectionString);
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

        /// <summary>
        /// PreSave method for preparing data before saving.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="objDto">The DTO object to convert.</param>
        public void PreSave(int? id, DTOEMP01 objDto)
        {
            _objEMP01 = objDto.Convert<EMP01>();
            if (Type == EnmType.E)
            {
                if (id > 0)
                {
                    _id = (int)id;
                }
            }
        }

        /// <summary>
        /// Validates the object before saving.
        /// </summary>
        /// <returns>A response object indicating validation success or failure.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct id";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the object.
        /// </summary>
        /// <returns>A response object indicating the result of the save operation.</returns>
        public Response Save()
        {
            if (Type == EnmType.A)
            {
                return Add(_objEMP01);
            }
            if (Type == EnmType.E)
            {
                return Update(_id, _objEMP01);
            }
            return _objResponse;
        }
    }
}
