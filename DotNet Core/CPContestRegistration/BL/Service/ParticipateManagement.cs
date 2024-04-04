using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace CPContestRegistration.BL.Service
{
    /// <summary>
    /// Service class for managing participation in contests.
    /// </summary>
    public class ParticipateManagement : IParticipateManagement
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
        /// Constructor for ParticipateManagement.
        /// </summary>
        /// <param name="databaseService">Database service instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public ParticipateManagement(IDatabaseService databaseService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _databaseService = databaseService;
            _loggerService = loggerService;
            HttpContext = httpContextAccessor.HttpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        /// <summary>
        /// Adds a new participation 
        /// </summary>
        /// <param name="objPAR01">The participation  object to add</param>
        /// <returns>True if the operation was successful, otherwise false</returns>
        public bool Add(PAR01 objPAR01)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                if (claimID == objPAR01.R01F02)
                {
                    objPAR01.R01F04 = DateTime.Now;
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.Insert(objPAR01);
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
        /// Updates an existing participation
        /// </summary>
        /// <param name="objPAR01">The participation object to update</param>
        /// <returns>True if the operation was successful, otherwise false</returns>k
        public bool Update(PAR01 objPAR01)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                if (claimID == objPAR01.R01F02)
                {
                    objPAR01.R01F04 = DateTime.Now;
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.Update(objPAR01);
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
        /// Deletes a participation based on ID
        /// </summary>
        /// <param name="id">The ID of the participation to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool Delete(int id)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                if (claimID == id)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.DeleteById<PAR01>(id);
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
        /// Retrieves all participation
        /// </summary>
        /// <returns>A DataTable containing all participation </returns>
        public DataTable SelectAll()
        {
            try
            {
                string role = HttpContext.User.GetRole();
                if (role == "Admin")
                {
                    return _databaseService.ExecuteQuery(@"SELECT
                                                    R01F01,
                                                    R01F02,
                                                    R01F03,
                                                    R01F04
                                                    FROM PAR01;");
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
        /// Retrieves a participation  based on ID
        /// </summary>
        /// <param name="id">The ID of the participation to retrieve</param>
        /// <returns>The participation  corresponding to the given ID, or null if not found</returns>
        public PAR01 SelectPk(int id)
        {
            try
            {
                int claimID = HttpContext.User.GetId();
                if (claimID == id)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        return db.SingleById<PAR01>(id);
                    }
                }

                throw new Exception("You are not Authorized");
            }
            catch (Exception ex)
            {
                _loggerService.ErrorLog(ex);
                return null;
            }
        }
    }
}
