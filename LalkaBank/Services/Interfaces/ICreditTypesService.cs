using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditTypesService
    {
        void Create(CreditTypesSet creditTypes);

        CreditTypesSet Get(Guid id);

        void Delete(Guid id);

        List<CreditTypesSet> GetList();

    }
}
