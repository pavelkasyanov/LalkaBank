using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IPersonDAO
    {
        void Create(Person person);

        Person Get(Guid id);

        void Delete(Guid id);

        List<Person> GetList();

        void Update(Person person);
    }
}
