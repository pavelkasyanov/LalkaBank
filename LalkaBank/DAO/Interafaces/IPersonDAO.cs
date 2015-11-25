using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface IPersonDAO
    {
         void Create(PersonSet person);
        PersonSet Get(Guid id);
         void Delete(Guid id);
         List<PersonSet> GetList();
    }
}
