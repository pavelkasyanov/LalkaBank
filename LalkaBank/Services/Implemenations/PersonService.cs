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

        public void Create(PersonSet person)
        {
            _personDao.Create(person);

        }

        public PersonSet Get(Guid id)
        {
            return _personDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _personDao.Delete(id);
        }

        public List<PersonSet> GetList()
        {
            return _personDao.GetList();
        }

        public bool RegisterUser(PersonSet person, PassportSet passport)
        {
            var pers = _personDao.Get(person.PersonId);
            if (pers != null)
            {
                person.Passport_PassportId = pers.Passport_PassportId;
                _personDao.Update(person);

                var pass = _passportDao.Get(pers.Passport_PassportId);

                passport.PassportId = pass.PassportId;
                _passportDao.Create(passport);

                return true;
            }

            passport.PassportId = Guid.NewGuid();
            person.Passport_PassportId = passport.PassportId;

            _passportDao.Create(passport);
            _personDao.Create(person);

            return true;
        }

        private readonly IPersonDAO _personDao;
        private readonly IPassportDAO _passportDao;
    }
}
