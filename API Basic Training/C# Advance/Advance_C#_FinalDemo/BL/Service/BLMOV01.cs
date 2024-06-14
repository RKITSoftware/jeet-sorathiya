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
    /// Business logic class for handling MOV01 data operations.
    /// </summary>
    [LoggingExceptionFilter]
    public class BLMOV01 : IDataHandlerService<DTOMOV01>
    {
        #region Private Fields
        // Retrieve IDbConnectionFactory from the application context
        private readonly IDbConnectionFactory _dbFactory;
        private Response _objResponse;
        private MOV01 _objMOV01;
        private int _id;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the type of operation (Add/Edit).
        /// </summary>
        public EnmType Type { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BLMOV01"/> class.
        /// </summary>
        public BLMOV01()
        {
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
            _objMOV01 = new MOV01();
            _objResponse = new Response();
            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all MOV01 data.
        /// </summary>
        /// <returns>A list of MOV01 objects.</returns>
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
        /// Retrieves all movies along with their categories and directors.
        /// </summary>
        /// <returns>A HttpResponseMessage containing all movies with their categories and directors.</returns>
        public HttpResponseMessage GetAll()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
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
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(jsonData)
                    };

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
        /// Adds a new movie.
        /// </summary>
        /// <param name="newMovie">The movie object to add.</param>
        /// <returns>A response object indicating the result of the add operation.</returns>
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
        /// Updates an existing movie.
        /// </summary>
        /// <param name="newMovie">The movie object to update.</param>
        /// <returns>A response object indicating the result of the update operation.</returns>
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
        /// Deletes a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>A response object indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to delete a movie from the MOV01 table by ID
                    db.DeleteById<MOV01>(id);
                }
                _objResponse.Message = "Deleted";
            }
            catch (Exception ex)
            {
                // Handle and rethrow exception with additional information
                _objResponse.IsError = true;
                _objResponse.Message = "Not Deleted";
                throw new Exception(ex.Message);
            }
            return _objResponse;
        }

        /// <summary>
        /// Prepares the movie object for saving by converting the DTO object.
        /// </summary>
        /// <param name="objDto">The DTO object to convert.</param>
        public void PreSave(DTOMOV01 objDto)
        {
            _objMOV01 = objDto.Convert<MOV01>();
        }

        /// <summary>
        /// Validates the movie object.
        /// </summary>
        /// <returns>A response object indicating the result of the validation.</returns>
        public Response Validation()
        {
            return _objResponse;
        }

        /// <summary>
        /// Saves the movie object based on the operation type.
        /// </summary>
        /// <returns>A response object indicating the result of the save operation.</returns>
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
        #endregion
    }
}
