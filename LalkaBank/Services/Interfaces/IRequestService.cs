using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IRequestService
    {
        void Create(RequestSet request);

        RequestSet Get(Guid id);

        void Delete(Guid id);

        List<RequestSet> GetList();
    }
}
