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

        Guid? CreateCreditForRequest(Guid requestId);

        List<Credit> GetListByPersonId(Guid personId);

        Table GetTimeTable();
    }
}
