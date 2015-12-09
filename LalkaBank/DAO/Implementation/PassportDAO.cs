using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PassportDAO : IPassportDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Passport passport)
        {
            lock (Look)
            {
                _db.Passports.AddOrUpdate(passport);
                _db.SaveChanges();
            }
        }

        public Passport Get(Guid id)
        {
            lock (Look)
            {
                var passport = _db.Passports.Find(id);
                if (passport == null)
                {
                    throw new Exception("not found");
                }

                return passport;
            }
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var passport = _db.Passports.Find(id);
                if (passport == null)
                {
                    throw new Exception("not found");
                }

                _db.Passports.Remove(passport);
                _db.SaveChanges();
            }
        }

        public List<Passport> GetList()
        {
            lock (Look)
            {
                return _db.Passports.ToList();
            }
        }

        public void SaveToBase()
        {
            lock (Look)
            {
                _db.SaveChanges();
            }
        }
    }
}
