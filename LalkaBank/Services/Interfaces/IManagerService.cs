using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IManagerService
    {
        void Create(ManagerSet manager);

        ManagerSet Get(Guid id);

        void Delete(Guid id);

        List<ManagerSet> GetList();
    }
}
