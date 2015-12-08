using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditTypesService
    {
        bool Create(CreditType creditTypes);

        CreditType Get(Guid id);

        bool Delete(Guid id);

        List<CreditType> GetList();

    }
}
