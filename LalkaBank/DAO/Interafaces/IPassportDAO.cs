using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IPassportDAO
    {
        void Create(Passport passport);

        Passport Get(Guid id);

        void Delete(Guid id);

        List<Passport> GetList();
    }
}
