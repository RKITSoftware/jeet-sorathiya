using CPContestRegistration.Models;
using System.Data;

namespace CPContestRegistration.BL.Interface
{
    public interface IParticipateManagement
    {
        bool Add(PAR01 objPAR01);
        bool Delete(int id);
        DataTable SelectAll();
        PAR01 SelectPk(int id);
        bool Update(PAR01 objPAR01);
    }
}