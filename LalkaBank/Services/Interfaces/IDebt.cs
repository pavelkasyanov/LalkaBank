using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Services
{
    interface IDebt
    {
        void Create(DebtsSet debts);
        DebtsSet Get(Guid id);
        void Delete(Guid id);
        List<DebtsSet> GetList();
    }
}
