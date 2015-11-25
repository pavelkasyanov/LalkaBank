using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface IManagerDAO
    {
         void Create(ManagerSet manager);
        ManagerSet Get(Guid id);
         void Delete(Guid id);
         List<ManagerSet> GetList();
    }
}
