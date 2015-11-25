using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface IRequestDAO
    {
         void Create(RequestSet request);
        RequestSet Get(Guid id);
         void Delete(Guid id);
         List<RequestSet> GetList();
    }
}
