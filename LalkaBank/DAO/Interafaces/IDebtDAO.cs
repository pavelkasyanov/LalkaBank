using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IDebtDAO
    {
        void CreateOrUpdate(Debts debts);

        Debts Get(Guid id);

        void Delete(Guid id);

        List<Debts> GetList();
    }
}
