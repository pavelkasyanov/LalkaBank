using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PersonDAO : IPersonDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static Object Look = new object();

        public void CreateOrUpdate(Person person)
        {
            lock (Look)
            {
                _db.Persons.AddOrUpdate(person);
                _db.SaveChanges();
            }
        }

        public Person Get(Guid id)
        {
            lock (Look)
            {
                var person = _db.Persons.Find(id);
                return person;
            }
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var person = _db.Persons.Find(id);
                if (person == null) { throw new Exception("not found"); }

                _db.Persons.Remove(person);
                _db.SaveChanges();
            }
        }

        public void Update(Person person)
        {
            lock (Look)
            {
                _db.Persons.AddOrUpdate(person);
                _db.SaveChanges();
            }
        }

        public List<Person> GetList()
        {
            lock (Look)
            {
                return _db.Persons.ToListAsync().Result;
            }
        }
    }
}
