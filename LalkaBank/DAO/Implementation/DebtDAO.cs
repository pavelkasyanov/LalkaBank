using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class DebtDAO : IDebtDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void CreateOrUpdate(Debts debt)
        {
            _db.Debts.AddOrUpdate(debt);
            _db.SaveChanges();
        }

        public Debts Get(Guid id)
        {
            //var debt = _db.DebtsSets.ToList().FirstOrDefault(x => x.DebtsId == id);
            var debt = _db.Debts.Find(id);
            if (debt != null)
            {
                return debt;
            }

            throw new Exception("not found");
        }

        public void Delete(Guid id)
        {
            var debt = _db.Debts.Find(id);

            if (debt == null) { throw new Exception("not found"); }

            _db.Debts.Remove(debt);
            _db.SaveChanges();
        }

        public List<Debts> GetList()
        {
            return _db.Debts.ToList();
        }
    }
}
