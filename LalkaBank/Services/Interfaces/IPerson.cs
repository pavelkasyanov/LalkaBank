using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Services
{
    interface IPerson
    {
        void Create(PersonSet person);
        PersonSet Get(Guid id);
        void Delete(Guid id);
        List<PersonSet> GetList();
    }
}
