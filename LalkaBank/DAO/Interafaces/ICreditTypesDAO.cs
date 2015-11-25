using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface ICreditTypesDAO
    {
         void Create(CreditTypesSet credit_types);
         CreditTypesSet GetById(Guid id);
         void Delete(Guid id);
         List<CreditTypesSet> GetList();
    }
}
