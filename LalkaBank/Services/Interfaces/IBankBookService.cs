using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IBankBookService
    {
        bool Create(BankBook credit);

        BankBook Get(Guid id);

        bool Delete(Guid id);

        bool Update(BankBook id);

        List<BankBook> GetList();
    }
}
