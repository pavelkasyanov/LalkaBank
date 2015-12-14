using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditHistoryService
    {
        bool Create(CreditHistory debts);


        CreditHistory Get(Guid id);

        bool Delete(Guid id);

        List<CreditHistory> GetList();

        List<CreditHistory> GetListFromCredit(Guid creditId);
    }
}
