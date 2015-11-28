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

        public void Create(PersonSet person)
        {
            _db.PersonSets.Add(person);
            _db.SaveChanges();
        }

        public PersonSet Get(Guid id)
        {
            var person = _db.PersonSets.Find(id);
            return person;
        }

        public void Delete(Guid id)
        {
            var person = _db.PersonSets.Find(id);
            if (person == null) { throw new Exception("not found"); }

            _db.PersonSets.Remove(person);
            _db.SaveChanges();
        }

        public void Update(PersonSet person)
        {
            _db.PersonSets.AddOrUpdate(person);
            _db.SaveChanges();

        }

        public List<PersonSet> GetList()
        {
            return _db.PersonSets.ToList();
        }
    }
}
