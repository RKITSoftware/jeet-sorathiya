using CPContestRegistration.BL.Interface;
using CPContestRegistration.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace CPContestRegistration.BL.Service
{
    public class ParticipateManagement : IParticipateManagement
    {
        private readonly IDatabaseService _databaseService;
        private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;

        public ParticipateManagement(IDatabaseService databaseService, IConfiguration configuration)
        {
            _databaseService = databaseService;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        public bool Add(PAR01 objPAR01)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Insert(objPAR01);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(PAR01 objPAR01)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    db.Update(objPAR01);
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
                    db.DeleteById<PAR01>(id);
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
                                                    R01F01
                                                    R01F02
                                                    R01F03
                                                    R01F04
                                                    FROM PAR01");
        }

        public PAR01 SelectPk(int id)
        {
            try
            {
                using (var db = _connectionFactory.OpenDbConnection())
                {
                    return db.SingleById<PAR01>(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
