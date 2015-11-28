using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IBankBookDAO
    {
        void Create(BankBookSet credit);
        BankBookSet Get(Guid id);
        void Delete(Guid id);
        void Update(BankBookSet id);
        List<BankBookSet> GetList();
    }
}
