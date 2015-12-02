using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IDebtService
    {
        void Create(Debts debts);


        Debts Get(Guid id);

        void Delete(Guid id);

        List<Debts> GetList();
    }
}
