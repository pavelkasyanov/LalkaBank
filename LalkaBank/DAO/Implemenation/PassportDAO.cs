using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PassportDAO : IPassportDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(Passport passport)
        {
            _db.Passports.AddOrUpdate(passport);
            _db.SaveChanges();
        }

        public Passport Get(Guid id)
        {
            var passport = _db.Passports.Find(id);
            if (passport == null) { throw new Exception("not found"); }

            return passport;
        }

        public void Delete(Guid id)
        {
            var passport = _db.Passports.Find(id);
            if (passport == null) { throw new Exception("not found"); }

            _db.Passports.Remove(passport);
            _db.SaveChanges();
        }

        public List<Passport> GetList()
        {
            return _db.Passports.ToList();
        }
    }
}
