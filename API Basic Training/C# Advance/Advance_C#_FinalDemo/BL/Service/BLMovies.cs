using Advance_C__FinalDemo.BL.Interface;
using Advance_C__FinalDemo.Extension;
using Advance_C__FinalDemo.Models;
using Advance_C__FinalDemo.Models.DTO;
using Advance_C__FinalDemo.Models.Enum;
using Advance_C__FinalDemo.Models.POCO;
using Newtonsoft.Json;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Advance_C__FinalDemo.BL
{
    /// <summary>
    /// Business logic class for managing CRUD operations on the MOV01 table.
    /// </summary>
    [LoggingExceptionFilter]
    public class BLMovies : IDataHandlerService<DTOMOV01>
    {
        // Retrieve IDbConnectionFactory from the application context
        private readonly IDbConnectionFactory _dbFactory;
        private Response _objResponse;
        private MOV01 _objMOV01;
        private int _id;

        public EnmType Type { get; set; }


        /// <summary>
        /// Initializes a new instance of the BLMovies class.
        /// </summary>
        public BLMovies()
        {
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
            _objMOV01 = new MOV01();
            _objResponse = new Response();
            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Retrieves a list of MOV01 data from the database
        /// </summary>
        /// <returns>A list of MOV01 objects</returns>
        public List<MOV01> GetData()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    List<MOV01> movies = db.Select<MOV01>();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                throw new Exception($"Error retrieving MOV01 data: {ex.Message}");
            }
        }


        /// <summary>
        /// Retrieves movies along with their category and director information.
        /// </summary>
        /// <returns>HttpResponseMessage containing the JSON type movies.</returns>
        public HttpResponseMessage GetAll()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    //List<MOV01> movies = db.Select<MOV01>();
                    // Define SQL query to join MOV01, CAT01, and DIR01 tables
                    var joinSQL = db.From<MOV01>()
                                    .Join<CAT01>((m, c) => m.V01F04 == c.T01F01)
                                    .Join<DIR01>((m, d) => m.V01F05 == d.R01F01);

                    // Execute the multi-table join query and project the result into an anonymous type
                    var result = db.SelectMulti<MOV01, CAT01, DIR01>(joinSQL)
                                    .Select(r => new
                                    {
                                        MovieID = r.Item1.V01F01,
                                        MovieName = r.Item1.V01F02,
                                        MovieDate = r.Item1.V01F03,
                                        CategoryName = r.Item2.T01F02,
                                        DirectorName = r.Item3.R01F02
                                    }).ToList();

                    // Serialize the result to JSON format
                    string jsonData = JsonConvert.SerializeObject(result, Formatting.Indented);
                    // Create a new HTTP response message with OK status
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                    // Set the response content to the serialized JSON data
                    response.Content = new StringContent(jsonData);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Return the HTTP response message
                    return response;
                }
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="newMovie">The MOV01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        public Response Add(MOV01 newMovie)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to insert a new movie into the MOV01 table
                    db.Insert(newMovie);
                }
                _objResponse.Message = "Data Added";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Data Not Added";
                // Handle and rethrow exception with additional information
                throw new Exception(ex.Message);
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing movie in the database.
        /// </summary>
        /// <param name="newMovie">The MOV01 object </param>
        /// <returns>A Response object indicating the outcome of the operation.</returns>
        public Response Update(MOV01 newMovie)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to update an existing movie in the MOV01 table
                    db.Update(newMovie);
                }
                _objResponse.Message = "Data Is Updated";
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Internal Error";
                throw new Exception(ex.Message);
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a movie from the MOV01 table by ID.
        /// </summary>
        /// <param name="id">Movie ID to be deleted</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Delete(int id)
        {
            bool isResponse = true;
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to delete a movie from the MOV01 table by ID
                    db.DeleteById<MOV01>(id);
                }
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                isResponse = false;
                throw new Exception(ex.Message);
            }
            return isResponse;
        }

        /// <summary>
        /// Prepares the object for saving MOV01 object 
        /// </summary>
        /// <param name="id">The ID of the object, if available.</param>
        /// <param name="objDto">The DTOMOV01 object containing data to be converted and saved.</param>
        public void PreSave(int? id, DTOMOV01 objDto)
        {
            _objMOV01 = objDto.Convert<MOV01>();
        }

        /// <summary>
        /// Performs validation before saving.
        /// </summary>
        /// <returns>A Response object indicating the outcome of the validation.</returns>
        public Response Validation()
        {

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
                return Add(_objMOV01);
            }
            if (Type == EnmType.E)
            {
                return Update(_objMOV01);
            }
            _objResponse.IsError = true;
            _objResponse.Message = "Internal Error";
            return _objResponse;
        }
    }
}