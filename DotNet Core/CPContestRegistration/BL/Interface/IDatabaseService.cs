using System.Data;

namespace CPContestRegistration.BL.Interface
{
    public interface IDatabaseService
    {
        DataTable ExecuteQuery(string query);
    }
}
