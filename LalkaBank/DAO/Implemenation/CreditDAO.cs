using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class CreditDAO : ICreditDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer(); 
    
        public void Create(Credit credit)
        {
            _db.Credits.Add(credit);
            _db.SaveChanges();
        }

        public Credit Get(Guid id)
        {
            var credit = _db.Credits.Find(id);
            if (credit == null)
                throw new Exception("not found");
            else
                return credit;
        }

        public void Delete(Guid id)
        {
            var credit = _db.Credits.Find(id);
            if (credit != null)
            {
                _db.Credits.Remove(credit);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("not found");
            }

        }

        public List<Credit> GetList()
        {
            return _db.Credits.ToList();
        }
    }
}
