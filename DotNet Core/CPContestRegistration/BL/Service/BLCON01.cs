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
    /// Service class for managing contests.
    /// </summary>
    public class BLCON01 : ICON01
    {
        #region Private Fields
        private readonly IDatabaseService _databaseService;
        private readonly ILoggerService _loggerService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;
        private Response _objResponse;
        private CON01 _objCON01;
        #endregion

        #region Public Properties
        /// <summary>
        /// HttpContext instance.
        /// </summary>
        public HttpContext HttpContext { get; }

        /// <summary>
        /// Specify Operation type
        /// </summary>
        public EnmOperation Operation { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for ContestManagement.
        /// </summary>
        /// <param name="databaseService">Database service instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public BLCON01(IDatabaseService databaseService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _databaseService = databaseService;
            _loggerService = loggerService;
            HttpContext = httpContextAccessor.HttpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
            _objResponse = new Response();
            _objCON01 = new CON01();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Deletes a contest entry by its is
        /// </summary>
        /// <param name="id">The id of the contest to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {
            if (id > 0)
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.DeleteById<CON01>(id);
                }
                _objResponse.Message = "Data Deleted";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Invalid ID";
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves all contest entries.
        /// </summary>
        /// <returns>A response containing a list of all contest.</returns>
        public Response SelectAll()
        {
            //return _databaseService.ExecuteQuery(@"SELECT 
            //                                            N01F01, 
            //                                            N01F02, 
            //                                            N01F03, 
            //                                            N01F04 
            //                                        FROM CON01;");

            using (var db = _connectionFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<CON01>();
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a contest entry by id.
        /// </summary>
        /// <param name="id">The id of the contest</param>
        /// <returns>A response containing the contest</returns>
        public Response SelectPk(int id)
        {
            using (var db = _connectionFactory.OpenDbConnection())
            {
                _objResponse.Data = db.SingleById<CON01>(id);
            }
            return _objResponse;
        }

        /// <summary>
        /// Converts the DTO to POCO conversion and initialize the fields which are neccessary.
        /// </summary>
        /// <param name="objDto">DTO cntaining the model information.</param>
        public void PreSave(DTOCON01 objDto)
        {
            _objCON01 = objDto.Convert<CON01>();
        }

        /// <summary>
        /// Validate the poco model's properties.
        /// </summary>
        /// <returns>Response according to the operation.</returns>
        public Response Validation()
        {
            if (Operation == EnmOperation.E)
            {
                if (!(_objCON01.N01F01 > 0))
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
                    db.Insert(_objCON01);
                }
                _objResponse.Message = "Data Added";
            }
            if (Operation == EnmOperation.E)
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Update(_objCON01);
                }
                _objResponse.Message = "Data Update";
            }
            return _objResponse;
        }
        #endregion
    }
}
