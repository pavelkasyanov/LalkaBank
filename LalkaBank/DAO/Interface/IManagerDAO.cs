using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IManagerDAO
    {
         void Create(Manager manager);
         Manager Get(Guid id);
         void Delete(Guid id);
         List<Manager> GetList();
    }
}
