using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    class DebtsDAO : IDebtsDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(DebtsSet debt)
        {
            _db.DebtsSets.Add(debt);
            _db.SaveChanges();
        }

        public DebtsSet Get(Guid id)
        {
            DebtsSet debt = _db.DebtsSets.Find(id);
            if (debt == null)
                throw new Exception("not found");
            else
                return debt;
        }

        public void Delete(Guid id)
        {
            var debt = _db.DebtsSets.Find(id);
            if (debt == null)
                throw new Exception("not found");
            else
            {
                _db.DebtsSets.Remove(debt);
                _db.SaveChanges();
            }

        }

        public List<DebtsSet> GetList()
        {
            return _db.DebtsSets.ToList();
        }
    }
}
