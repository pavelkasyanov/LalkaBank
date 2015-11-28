using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IDebtService
    {
        void Create(DebtsSet debts);


        DebtsSet Get(Guid id);

        void Delete(Guid id);

        List<DebtsSet> GetList();
    }
}
