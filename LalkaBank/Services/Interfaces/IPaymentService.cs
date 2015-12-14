using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPaymentService
    {
        bool Create(Payments payment);

        Payments Get(Guid id);

        bool Delete(Guid id);

        List<Payments> GetList();
    }
}
