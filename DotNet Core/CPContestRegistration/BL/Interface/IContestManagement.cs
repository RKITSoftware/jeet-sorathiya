using CPContestRegistration.Models;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    public interface IContestManagement
    {
        bool Add(CON01 objCON01);
        bool Delete(int id);
        DataTable SelectAll();
        CON01 SelectPk(int id);
        bool Update(CON01 objCON01);
    }
}