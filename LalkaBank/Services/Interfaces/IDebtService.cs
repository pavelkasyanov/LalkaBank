using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IDebtService
    {
        bool Create(Debts debts);


        Debts Get(Guid id);

        bool Delete(Guid id);

        List<Debts> GetList();
    }
}
