using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IPersonDAO
    {
         void Create(Person person);
         Person Get(Guid id);
         void Delete(Guid id);
         List<Person> GetList();
    }
}
