using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PassportDAO : IPassportDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(PassportSet passport)
        {
            _db.PassportSets.Add(passport);
            _db.SaveChanges();
        }

        public PassportSet Get(Guid id)
        {
            var passport = _db.PassportSets.Find(id);
            if (passport == null) { throw new Exception("not found"); }

            return passport;
        }

        public void Delete(Guid id)
        {
            var passport = _db.PassportSets.Find(id);
            if (passport == null) { throw new Exception("not found"); }

            _db.PassportSets.Remove(passport);
            _db.SaveChanges();
        }

        public List<PassportSet> GetList()
        {
            return _db.PassportSets.ToList();
        }
    }
}
