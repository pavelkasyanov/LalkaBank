using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IPasportDAO
    {
         void Create(Passport passport);
         Passport Get(Guid id);
         void Delete(Guid id);
         List<Passport> GetList();
    }
}
