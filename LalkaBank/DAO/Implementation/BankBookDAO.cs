using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implementation
{
    // ReSharper disable once InconsistentNaming
    public class BankBookDAO : IBankBookDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(BankBook book)
        {
            lock (Look)
            {
                _db.BankBooks.AddOrUpdate(book);
                _db.SaveChanges();
            }
        }

        public BankBook Get(Guid id)
        {
            lock (Look)
            {
                return _db.BankBooks.Find(id);
            }
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var book = _db.BankBooks.FindAsync(id).Result;
                if (book == null) return;

                _db.BankBooks.Remove(book);
                _db.SaveChanges();
            }

        }
        public void  Update(BankBook book)
        {
            lock (Look)
            {
                var old = book;
                _db.BankBooks.Add(old);
                _db.SaveChanges();
            }

        }

        public List<BankBook> GetList()
        {
            lock (Look)
            {
                return _db.BankBooks.ToList();
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
