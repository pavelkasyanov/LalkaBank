using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface ICreditService
    {
        void Create(Credit credit);

        Credit Get(Guid id);

        void Delete(Guid id);

        List<Credit> GetList();

        bool CreateCreditForRequest(Guid requestId);
    }
}
