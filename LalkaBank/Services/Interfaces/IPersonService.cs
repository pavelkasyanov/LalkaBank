using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        void Create(PersonSet person);

        PersonSet Get(Guid id);

        void Delete(Guid id);

        List<PersonSet> GetList();
    }
}
