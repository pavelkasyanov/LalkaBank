using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        bool Create(Person person);

        Person Get(Guid id);

        bool Delete(Guid id);

        List<Person> GetList();

        bool RegisterUser(Person person, Passport passport);

        bool IsUserRegister(Guid userId);
    }
}
