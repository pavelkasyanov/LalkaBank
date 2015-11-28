using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPaymentService
    {
        void Create(PaymentsSet payment);

        PaymentsSet Get(Guid id);

        void Delete(Guid id);

        List<PaymentsSet> GetList();
    }
}
