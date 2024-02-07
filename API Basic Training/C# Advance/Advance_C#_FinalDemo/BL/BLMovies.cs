using Advance_C__FinalDemo.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
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
        /// Retrieves all movies from the MOV01 table.
        /// </summary>
        /// <returns>List of MOV01 objects representing all movies</returns>
        public List<MOV01> GetAll()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    // Execute SQL command to select all movies from the MOV01 table
                    List<MOV01> movies = db.Select<MOV01>();
                    return movies;
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