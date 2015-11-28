using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface ICreditTypesDAO
    {
        void Create(CreditTypesSet creditTypes);

        CreditTypesSet GetById(Guid id);

        void Delete(Guid id);

        List<CreditTypesSet> GetList();
    }
}
