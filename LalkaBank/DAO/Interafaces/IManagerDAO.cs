using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IManagerDAO : IContexstSave
    {
        void CreateOrUpdate(Manager manager);

        Manager Get(Guid id);

        void Delete(Guid id);

        List<Manager> GetList();
    }
}
