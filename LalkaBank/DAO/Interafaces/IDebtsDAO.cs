using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IDebtsDAO
    {
        void Create(DebtsSet debts);

        DebtsSet Get(Guid id);

        void Delete(Guid id);

        List<DebtsSet> GetList();
    }
}
