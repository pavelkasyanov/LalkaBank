using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IManagerService
    {
        void Create(Manager manager);

        Manager Get(Guid id);

        void Delete(Guid id);

        List<Manager> GetList();
    }
}
