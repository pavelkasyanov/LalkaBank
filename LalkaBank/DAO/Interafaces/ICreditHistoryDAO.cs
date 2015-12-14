using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interafaces
{
    public interface ICreditHistoryDAO
    {
        void CreateOrUpdate(CreditHistory credit);

        CreditHistory Get(Guid id);

        void Delete(Guid id);

        List<CreditHistory> GetList();
    }
}
