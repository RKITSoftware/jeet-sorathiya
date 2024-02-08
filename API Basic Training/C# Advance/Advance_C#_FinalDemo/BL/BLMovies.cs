using Advance_C__FinalDemo.Models;
using Newtonsoft.Json;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System;
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
    [LoggingExceptionFilterAttribute]
    public class BLMovies
    {
        // Retrieve IDbConnectionFactory from the application context
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Constructor initializes IDbConnectionFactory from the application context.
        /// </summary>
        public BLMovies()
        {
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Retrieves movies along with their category and director information.
        /// </summary>
        /// <returns>HttpResponseMessage containing the JSON representation of the retrieved movies.</returns>

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
        /// Adds a new movie to the MOV01 table.
        /// </summary>
        /// <param name="newMovie">MOV01 object representing the new movie to be added</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Add(MOV01 newMovie)
        {
            bool isResponse = true;
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to insert a new movie into the MOV01 table
                    db.Insert(newMovie);
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
        /// Updates an existing movie in the MOV01 table.
        /// </summary>
        /// <param name="newMovie">MOV01 object representing the updated movie data</param>
        /// <returns>Boolean indicating the success or failure of the operation</returns>
        public bool Update(MOV01 newMovie)
        {
            bool isResponse = true;
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Check if the movie object is not null before updating
                    if (newMovie != null)
                    {
                        // Execute SQL command to update an existing movie in the MOV01 table
                        db.Update(newMovie);
                    }
                    else
                    {
                        // If the movie object is null, set the response to false
                        isResponse = false;
                    }
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
    }
}