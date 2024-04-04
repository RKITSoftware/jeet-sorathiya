using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;
using System.Security.Claims;

namespace CPContestRegistration.BL.Service
{
    /// <summary>
    /// Service class for managing user-related operations.
    /// </summary>
    public class UserManagement : IUserManagement
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILoggerService _loggerService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;

        /// <summary>
        /// HttpContext instance.
        /// </summary>
        public HttpContext HttpContext { get; }

        /// <summary>
        /// Constructor for UserManagement.
        /// </summary>
        /// <param name="databaseService">Database service instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public UserManagement(IDatabaseService databaseService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _databaseService = databaseService;
            _loggerService = loggerService;
            HttpContext = httpContextAccessor.HttpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="objUSE01">The user  object to add</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        public bool Add(USE01 objUSE01)
        {
            try
            {

                string role = HttpContext.User.GetRole();
                if (role == "Admin")
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.Insert(objUSE01);
                    }
                    return true;
                }
                throw new Exception("You are not Authorized");

            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return false;
            }
        }

        /// <summary>
        /// Updates an existing user .
        /// </summary>
        /// <param name="objUSE01">The user  object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool Update(USE01 objUSE01)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                string role = HttpContext.User.GetRole();

                if (role == "Admin" || claimID == objUSE01.E01F01)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.Update(objUSE01);
                    }
                    return true;
                }
                throw new Exception("You are not Authorized");
            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return false;
            }
        }

        /// <summary>
        /// Deletes a user based on its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool Delete(int id)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                string role = HttpContext.User.GetRole();
                if (role == "Admin" || claimID == id)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.DeleteById<USE01>(id);
                    }
                    return true;
                }
                throw new Exception("You are not Authorized");

            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return false;
            }
        }

        /// <summary>
        /// Retrieves all user 
        /// </summary>
        /// <param name="isInternalCall">Optional parameter indicating if the call is internal.</param>
        /// <returns>A DataTable containing all user entries.</returns>
        public DataTable SelectAll(bool isInternalCall = false)
        {
            try
            {
                if (isInternalCall || (HttpContext.User.GetRole() == "Admin"))
                {
                    return _databaseService.ExecuteQuery(@"SELECT
                                            E01F01,
                                            E01F02,
                                            E01F03,
                                            E01F04
                                        FROM USE01");
                }



                throw new Exception("You are not Authorized");
            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return null;
            }


        }

        /// <summary>
        /// Retrieves a user  based on ID
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns>The user  corresponding to the given ID, or null if not found.</returns>
        public USE01 SelectPk(int id)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                string role = HttpContext.User.GetRole();

                if (role == "Admin" || claimID == id)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        return db.SingleById<USE01>(id);

                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return null;
            }
        }
    }
}
