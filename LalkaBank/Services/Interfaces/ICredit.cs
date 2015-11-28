using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Services
{
    interface ICredit
    {
        void Create(CreditSet credit);
        CreditSet Get(Guid id);
        void Delete(Guid id);
        List<CreditSet> GetList();
    }
}
