using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IRequestDAO
    {
        void Create(Request request);

        Request Get(Guid id);

        void Delete(Guid id);

        List<Request> GetList();
    }
}
