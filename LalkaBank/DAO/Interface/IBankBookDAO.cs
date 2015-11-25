using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IBankBookDAO
    {
        void Create(BankBook credit);
        BankBook Get(Guid id);
        void Delete(Guid id);
        void Update(BankBook id);
        List<BankBook> GetList();
    }
}
