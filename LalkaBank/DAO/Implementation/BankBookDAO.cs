using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class BankBookDAO : IBankBookDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void CreateOrUpdate(BankBook book)
        {
            _db.BankBooks.AddOrUpdate(book);
            _db.SaveChanges();
        }

        public BankBook Get(Guid id)
        {
            var book = _db.BankBooks.Find(id);
            if (book == null)
                throw new Exception("not found");
            else
                return book;
        }

        public void Delete(Guid id)
        {
            var book = _db.BankBooks.Find(id);
            if (book == null)
                throw new Exception("not found");
            else
            {
                _db.BankBooks.Remove(book);
                _db.SaveChanges();
            }

        }
        public void  Update(BankBook book)
        {
            var old = book;
            _db.BankBooks.Add(old);
            _db.SaveChanges();

        }

        public List<BankBook> GetList()
        {
            return _db.BankBooks.ToList();
        }

    }
}
