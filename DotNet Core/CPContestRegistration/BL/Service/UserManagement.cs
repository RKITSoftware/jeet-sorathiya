using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace CPContestRegistration.BL.Service
{
    public class UserManagement : IUserManagement
    {
        private readonly IDatabaseService _databaseService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;


        public UserManagement(IDatabaseService databaseService, IConfiguration configuration)
        {
            _databaseService = databaseService;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        public bool Add(USE01 objUSE01)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Insert(objUSE01);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(USE01 objUSE01)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Update(objUSE01);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Delete<USE01>(id);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable SelectAll()
        {
            return _databaseService.ExecuteQuery(@"SELECT
                                                        E01F01,
                                                        E01F02,
                                                        E01F03,
                                                        E01F04
                                                    FROM USE01");
        }

        public USE01 SelectPk(int id)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    return db.SingleById<USE01>(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
