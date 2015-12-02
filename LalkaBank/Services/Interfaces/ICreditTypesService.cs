using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditTypesService
    {
        void Create(CreditType creditTypes);

        CreditType Get(Guid id);

        void Delete(Guid id);

        List<CreditType> GetList();

    }
}
