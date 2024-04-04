using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace CPContestRegistration.BL.Service
{
    /// <summary>
    /// Service class for managing contests.
    /// </summary>
    public class ContestManagement : IContestManagement
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
        /// Constructor for ContestManagement.
        /// </summary>
        /// <param name="databaseService">Database service instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public ContestManagement(IDatabaseService databaseService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _databaseService = databaseService;
            _loggerService = loggerService;
            HttpContext = httpContextAccessor.HttpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        /// <summary>
        /// Adds a new contest
        /// </summary>
        /// <param name="objCON01">The contest object to add</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        public bool Add(CON01 objCON01)
        {
            try
            {
                string role = HttpContext.User.GetRole();
                if (role == "Admin")
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.Insert(objCON01);
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
        /// Updates an existing contest
        /// </summary>
        /// <param name="objCON01">The contest object to update</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        public bool Update(CON01 objCON01)
        {
            try
            {
                string role = HttpContext.User.GetRole();
                if (role == "Admin")
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.Update(objCON01);
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
        /// Deletes a contest based on ID
        /// </summary>
        /// <param name="id">The ID of the contest to delete.</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        public bool Delete(int id)
        {
            try
            {
                string role = HttpContext.User.GetRole();
                if (role == "Admin")
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.DeleteById<CON01>(id);
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
        /// Retrieves all contest as a DataTable
        /// </summary>
        /// <returns>A DataTable containing all contest </returns>
        public DataTable SelectAll()
        {
            return _databaseService.ExecuteQuery(@"SELECT 
                                                        N01F01, 
                                                        N01F02, 
                                                        N01F03, 
                                                        N01F04 
                                                    FROM CON01;");
        }

        /// <summary>
        /// Retrieves a contest based on ID
        /// </summary>
        /// <param name="id">The ID of the contest entry to retrieve.</param>
        /// <returns>The contest corresponding ID, or null if not found</returns>
        public CON01 SelectPk(int id)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    return db.SingleById<CON01>(id);
                }
            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return null;
            }
        }
    }
}
