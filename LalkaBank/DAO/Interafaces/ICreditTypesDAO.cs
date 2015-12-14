using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface ICreditTypesDAO : IContexstSave
    {
        void CreateOrUpdate(CreditType creditTypes);

        CreditType GetById(Guid id);

        void Delete(Guid id);

        List<CreditType> GetList();

        List<CreditSubType> GetCreditSubTypes();
    }
}
