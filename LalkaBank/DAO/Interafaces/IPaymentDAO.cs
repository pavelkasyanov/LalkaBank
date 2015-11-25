using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface IPaymentDAO
    {
         void Create(PaymentsSet payment);
        PaymentsSet Get(Guid id);
         void Delete(Guid id);
         List<PaymentsSet> GetList();
    }
}
