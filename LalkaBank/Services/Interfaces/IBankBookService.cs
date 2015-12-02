using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IBankBookService
    {
        void Create(BankBook credit);

        BankBook Get(Guid id);

        void Delete(Guid id);

        void Update(BankBook id);

        List<BankBook> GetList();
    }
}
