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
    
        public void Create(CreditSet credit)
        {
            _db.CreditSets.Add(credit);
            _db.SaveChanges();
        }

        public CreditSet Get(Guid id)
        {
            var credit = _db.CreditSets.Find(id);
            if (credit == null)
                throw new Exception("not found");
            else
                return credit;
        }

        public void Delete(Guid id)
        {
            var credit = _db.CreditSets.Find(id);
            if (credit != null)
            {
                _db.CreditSets.Remove(credit);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("not found");
            }

        }

        public List<CreditSet> GetList()
        {
            return _db.CreditSets.ToList();
        }
    }
}
