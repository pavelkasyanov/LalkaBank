using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IDebtsDAO
    {
         void Create(Debts debts);
         Debts Get(Guid id);
         void Delete(Guid id);
         List<Debts> GetList();
    }
}
