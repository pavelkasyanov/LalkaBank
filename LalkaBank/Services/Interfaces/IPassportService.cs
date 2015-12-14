using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPassportService
    {
        bool Create(Passport passport);

        Passport Get(Guid id);

        bool Delete(Guid id);

        List<Passport> GetList();
    }
}
