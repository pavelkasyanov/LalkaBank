using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;

namespace Services.Implemenations
{
    public class PersonService : IPersonService
    {
        [Obsolete("use other constructor")]
        public PersonService()
        {
            _personDao = new PersonDAO();
        }

        public PersonService(IPersonDAO personDao)
        {
            _personDao = personDao;
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

        private readonly IPersonDAO _personDao;
    }
}
