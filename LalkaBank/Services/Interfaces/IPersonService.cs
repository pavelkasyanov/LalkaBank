using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        void Create(Person person);

        Person Get(Guid id);

        void Delete(Guid id);

        List<Person> GetList();

        bool RegisterUser(Person person, Passport passport);
    }
}
