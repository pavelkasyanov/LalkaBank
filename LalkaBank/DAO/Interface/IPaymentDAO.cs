using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IPaymentDAO
    {
         void Create(Payments payment);
         Payments Get(Guid id);
         void Delete(Guid id);
         List<Payments> GetList();
    }
}
