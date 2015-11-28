using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditService
    {
        void Create(CreditSet credit);

        CreditSet Get(Guid id);

        void Delete(Guid id);

        List<CreditSet> GetList();
    }
}
