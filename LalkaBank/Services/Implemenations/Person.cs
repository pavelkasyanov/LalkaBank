using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;

namespace Services
{
    public class Person : IPerson
    {

        public PersonDAO personDAO = new PersonDAO();
        public void Create(PersonSet person)
        {
            personDAO.Create(person);

        }

        public DAO.PersonSet Get(Guid id)
        {

            return personDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            personDAO.Delete(id);
        }

        public List<DAO.PersonSet> GetList()
        {
            return personDAO.GetList();
        }
    }
}
