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
    /// Service class for managing participation in contests.
    /// </summary>
    public class BLPAR01 : IPAR01
    {
        #region Private Fields
        private readonly IDatabaseService _databaseService;
        private readonly ILoggerService _loggerService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;
        private Response _objResponse;
        private PAR01 _objPAR01;
        #endregion

        #region Public Properties
        /// <summary>
        /// HttpContext instance.
        /// </summary>
        public HttpContext HttpContext { get; }
        /// <summary>
        /// Get or set the operation to perform.
        /// </summary>
        public EnmOperation Operation { get; set; }
        #endregion

        #region Controler
        /// <summary>
        /// Constructor for ParticipateManagement.
        /// </summary>
        /// <param name="databaseService">Database service instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        /// <param name="loggerService">Logger service instance.</param>
        public BLPAR01(IDatabaseService databaseService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _objResponse = new Response();
            _objPAR01 = new PAR01();
            _databaseService = databaseService;
            _loggerService = loggerService;
            HttpContext = httpContextAccessor.HttpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Deletes a participation record by its id
        /// </summary>
        /// <param name="id">The id of the participation record to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {
            if (id > 0)
            {
                int claimID = HttpContext.User.GetId();
                if (claimID == id)
                {
                    using (var db = _connectionFactory.OpenDbConnection())
                    {
                        db.DeleteById<PAR01>(id);
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
        /// Retrieves all participation records.
        /// </summary>
        /// <returns>A response containing a list of all participation records.</returns>
        public Response SelectAll()
        {

            //return _databaseService.ExecuteQuery(@"SELECT
            //                                R01F01,
            //                                R01F02,
            //                                R01F03,
            //                                R01F04
            //                                FROM PAR01;");
            using (var db = _connectionFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<PAR01>();
            }

            return _objResponse;
        }

        /// <summary>
        /// Retrieves a participation record by its id
        /// </summary>
        /// <param name="id">The id of the participation record to retrieve.</param>
        /// <returns>A response containing the participation record with the specified id</returns>
        public Response SelectPk(int id)
        {

            int claimID = HttpContext.User.GetId();
            if (claimID == id)
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    _objResponse.Data = db.Select<PAR01>(p => p.R01F02 == id);
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
        public void PreSave(DTOPAR01 objDto)
        {
            _objPAR01 = objDto.Convert<PAR01>();
        }

        /// <summary>
        /// Validate the poco model's properties.
        /// </summary>
        /// <returns>Response according to the operation.</returns>
        public Response Validation()
        {
            int claimID = HttpContext.User.GetId();
            if (Operation == EnmOperation.A)
            {
                if (claimID != _objPAR01.R01F02)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "You are not Authorized";
                }
            }

            if (Operation == EnmOperation.E)
            {
                if (claimID != _objPAR01.R01F02)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "You are not Authorized";
                }
                if (!(_objPAR01.R01F01 > 0))
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
                _objPAR01.R01F04 = DateTime.Now; //??
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Insert(_objPAR01);
                }
                _objResponse.Message = "Data Added";
            }
            if (Operation == EnmOperation.E)
            {
                _objPAR01.R01F04 = DateTime.Now;
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Update(_objPAR01);
                }
                _objResponse.Message = "Data Update";
            }
            return _objResponse;
        }
        #endregion
    }

}

