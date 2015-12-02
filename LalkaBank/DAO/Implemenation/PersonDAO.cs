using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PersonDAO : IPersonDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
        }

        public Person Get(Guid id)
        {
            var person = _db.Persons.Find(id);
            return person;
        }

        public void Delete(Guid id)
        {
            var person = _db.Persons.Find(id);
            if (person == null) { throw new Exception("not found"); }

            _db.Persons.Remove(person);
            _db.SaveChanges();
        }

        public void Update(Person person)
        {
            _db.Persons.AddOrUpdate(person);
            _db.SaveChanges();

        }

        public List<Person> GetList()
        {
            return _db.Persons.ToList();
        }
    }
}
