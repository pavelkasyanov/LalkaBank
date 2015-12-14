using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IManagerService
    {
        bool Create(Manager manager);

        Manager Get(Guid id);

        bool Delete(Guid id);

        List<Manager> GetList();
    }
}
