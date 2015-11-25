using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface ICreditDAO
    {
         void Create(Credit credit);
         Credit Get(Guid id);
         void Delete(Guid id);
         List<Credit> GetList();

    }
}
