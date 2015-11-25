using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface ICreditTypesDAO
    {
         void Create(CreditTypes credit_types);
         CreditTypes Get(Guid id);
         void Delete(Guid id);
         List<CreditTypes> GetList();
    }
}
