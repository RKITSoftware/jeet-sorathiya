using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace CPContestRegistration.BL.Service
{
    public class ContestManagement : IContestManagement
    {
        private readonly IDatabaseService _databaseService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;

        public ContestManagement(IDatabaseService databaseService, IConfiguration configuration)
        {
            _databaseService = databaseService;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        public bool Add(CON01 objCON01)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Insert(objCON01);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(CON01 objCON01)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Update(objCON01);
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
                    db.DeleteById<CON01>(id);
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
                                                        N01F01, 
                                                        N01F02, 
                                                        N01F03, 
                                                        N01F04 
                                                    FROM CON01;");
        }

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
                return null;
            }
        }
    }
}
