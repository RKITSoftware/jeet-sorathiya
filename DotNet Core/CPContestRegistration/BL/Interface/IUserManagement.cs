using CPContestRegistration.Models;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    public interface IUserManagement
    {
        bool Add(USE01 objUSE01);
        bool Delete(int id);
        DataTable SelectAll();
        USE01 SelectPk(int id);
        bool Update(USE01 objUSE01);
    }
}