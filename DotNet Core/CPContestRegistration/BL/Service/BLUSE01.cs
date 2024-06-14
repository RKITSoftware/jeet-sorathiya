using CPContestRegistration.BL.Interface;
using CPContestRegistration.Extentions;
using CPContestRegistration.Models;
using CPContestRegistration.Models.DTO;
using CPContestRegistration.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace CPContestRegistration.BL.Service
{
    /// <summary>
    /// Service class for managing user-related operations.
    /// </summary>
    public class BLUSE01 : IUSE01
    {
        #region Private Fields
        private readonly IDatabaseService _databaseService;
        private readonly ILoggerService _loggerService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;
        private Response _objResponse;
        private USE01 _objUSE01;
        #endregion

        #region Public Fields
        /// <summary>
        /// HttpContext instance.
        /// </summary>
        public HttpContext HttpContext { get; }

        /// <summary>
        /// Get or set the operation to perform.
        /// </summary>
        public EnmOperation Operation { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for UserManagement.
        /// </summary>
        /// <param name="databaseService">Database service instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public BLUSE01(IDatabaseService databaseService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _objResponse = new Response();
            _objUSE01 = new USE01();
            _databaseService = databaseService;
            _loggerService = loggerService;
            HttpContext = httpContextAccessor.HttpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Deletes a user record by its id.
        /// </summary>
        /// <param name="id">The id of the user record to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {

            if (id > 0)
            {
                int claimID = HttpContext.User.GetId();
                string role = HttpContext.User.GetRole();
                if (role == "Admin" || claimID == id)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.DeleteById<USE01>(id);
                    }
                    _objResponse.Message = "Data Deleted";
                }
                else
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "You are not Authorized";
                }
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Invalid ID";
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves all user records.
        /// </summary>
        /// <param name="isInternalCall">Indicates whether the call is internal.</param>
        /// <returns>A response containing a list of all user records.</returns>
        public Response SelectAll(bool isInternalCall = false)
        {
            //if (isInternalCall || (HttpContext.User.GetRole() == "Admin"))
            //  {
            //      return _databaseService.ExecuteQuery(@"SELECT
            //                              E01F01,
            //                              E01F02,
            //                              E01F03,
            //                              E01F04
            //                          FROM USE01");
            //  }

            using (var db = _connectionFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<USE01>();
            }

            return _objResponse;
        }

        /// <summary>
        /// Retrieves a user record by its id.
        /// </summary>
        /// <param name="id">The id of the user record to retrieve.</param>
        /// <returns>A response containing the user record with the specified id.</returns>
        public Response SelectPk(int id)
        {
            int claimID = HttpContext.User.GetId();
            string role = HttpContext.User.GetRole();

            if (role == "Admin" || claimID == id)
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    _objResponse.Data = db.SingleById<USE01>(id);
                }
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "You are not Authorized";
            }
            return _objResponse;
        }

        /// <summary>
        /// Converts the DTO to POCO conversion and initialize the fields which are neccessary.
        /// </summary>
        /// <param name="objDto">DTO cntaining the model information.</param>
        public void PreSave(DTOUSE01 objDto)
        {
            _objUSE01 = objDto.Convert<USE01>();
        }

        /// <summary>
        /// Validate the poco model's properties.
        /// </summary>
        /// <returns>Response according to the operation.</returns>
        public Response Validation()
        {
            if (Operation == EnmOperation.E)
            {
                if (!(_objUSE01.E01F01 > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Performs the add or update operation specified by Operation.
        /// </summary>
        /// <returns>Response according to the operation.</returns>
        public Response Save()
        {
            if (Operation == EnmOperation.A)
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Insert(_objUSE01);
                }
                _objResponse.Message = "Data Added";
            }
            if (Operation == EnmOperation.E)
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Update(_objUSE01);
                }
                _objResponse.Message = "Data Update";
            }
            return _objResponse;
        } 
        #endregion
    }
}
