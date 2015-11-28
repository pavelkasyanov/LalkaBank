using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IRequestDAO
    {
        void Create(RequestSet request);

        RequestSet Get(Guid id);

        void Delete(Guid id);

        List<RequestSet> GetList();
    }
}
