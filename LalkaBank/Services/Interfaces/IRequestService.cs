using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IRequestService
    {
        bool Create(Request request);

        Request Get(Guid id);

        bool Delete(Guid id);

        List<Request> GetList();

        List<Request> GetListByPersonId(Guid personId);

        List<CreditType> GetCreditTypes();

        bool ConfirmRequest(Guid requestId, Guid managerId, string msg);

        bool DiscartRequest(Guid requestId, Guid managerId, string msg);
    }
}
