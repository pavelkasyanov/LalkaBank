using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPaymentService
    {
        void Create(Payments payment);

        Payments Get(Guid id);

        void Delete(Guid id);

        List<Payments> GetList();
    }
}
