using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface IPasportDAO
    {
         void Create(PassportSet passport);
        PassportSet Get(Guid id);
         void Delete(Guid id);
         List<PassportSet> GetList();
    }
}
