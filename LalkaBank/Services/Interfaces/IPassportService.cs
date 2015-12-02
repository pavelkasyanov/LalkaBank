using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPassportService
    {
        void Create(Passport passport);

        Passport Get(Guid id);

        void Delete(Guid id);

        List<Passport> GetList();
    }
}
