using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IPassportDAO
    {
        void Create(PassportSet passport);

        PassportSet Get(Guid id);

        void Delete(Guid id);

        List<PassportSet> GetList();
    }
}
