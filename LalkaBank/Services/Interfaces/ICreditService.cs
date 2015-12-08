using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditService
    {
        bool Create(Credit credit);

        Credit Get(Guid id);

        bool Delete(Guid id);

        List<Credit> GetList();

        bool CreateCreditForRequest(Guid requestId);
    }
}
