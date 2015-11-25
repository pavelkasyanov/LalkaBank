using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    class BankBookDAO : IBankBookDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(BankBookSet book)
        {
            _db.BankBookSets.Add(book);
            _db.SaveChanges();
        }

        public BankBookSet Get(Guid id)
        {
            BankBookSet book = _db.BankBookSets.Find(id);
            if (book == null)
                throw new Exception("not found");
            else
                return book;
        }

        public void Delete(Guid id)
        {
            BankBookSet book = _db.BankBookSets.Find(id);
            if (book == null)
                throw new Exception("not found");
            else
            {
                _db.BankBookSets.Remove(book);
                _db.SaveChanges();
            }

        }
        public void  Update(BankBookSet book)
        {
            var old = book;
            _db.BankBookSets.Add(old);
            _db.SaveChanges();

        }

        public List<BankBookSet> GetList()
        {
            
            return _db.BankBookSets.ToList();
        }

    }
}
