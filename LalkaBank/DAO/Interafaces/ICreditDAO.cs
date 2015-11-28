using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface ICreditDAO
    {
        void Create(CreditSet credit);

        CreditSet Get(Guid id);

        void Delete(Guid id);

        List<CreditSet> GetList();

    }
}
