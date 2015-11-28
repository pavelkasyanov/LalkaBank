using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IBankBookService
    {
        void Create(BankBookSet credit);
        BankBookSet Get(Guid id);
        void Delete(Guid id);
        void Update(BankBookSet id);
        List<BankBookSet> GetList();
    }
}
