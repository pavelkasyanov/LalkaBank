using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class PersonService : IPersonService
    {
        [Obsolete("use other constructor")]
        public PersonService()
        {
            _passportDao = new PassportDAO();
            _personDao = new PersonDAO();
        }

        public PersonService(IPersonDAO personDao, IPassportDAO passportDao)
        {
            _personDao = personDao;
            _passportDao = passportDao;
        }

        public void Create(Person person)
        {
            _personDao.CreateOrUpdate(person);

        }

        public Person Get(Guid id)
        {
            return _personDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _personDao.Delete(id);
        }

        public List<Person> GetList()
        {
            return _personDao.GetList();
        }

        public bool RegisterUser(Person person, Passport passport)
        {
            var pers = _personDao.Get(person.Id);
            if (pers != null)
            {
                person.PassportId = pers.PassportId;
                _personDao.Update(person);

                var pass = _passportDao.Get(pers.PassportId);

                passport.Id = pass.Id;
                _passportDao.CreateOrUpdate(passport);

                return true;
            }

            passport.Id = Guid.NewGuid();
            person.PassportId = passport.Id;

            _passportDao.CreateOrUpdate(passport);
            _personDao.CreateOrUpdate(person);

            return true;
        }

        private readonly IPersonDAO _personDao;
        private readonly IPassportDAO _passportDao;
    }
}
