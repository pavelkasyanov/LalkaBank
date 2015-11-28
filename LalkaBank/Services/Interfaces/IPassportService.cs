using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPassportService
    {
        void Create(PassportSet passport);

        PassportSet Get(Guid id);

        void Delete(Guid id);

        List<PassportSet> GetList();
    }
}
