using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class DebtDAO : IDebtDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Debts debt)
        {
            lock (Look)
            {
                _db.Debts.AddOrUpdate(debt);
                _db.SaveChanges();
            }
        }

        public Debts Get(Guid id)
        {
            lock (Look)
            {
                Debts debt = null;
                    debt = _db.Debts.Find(id);
                    if (debt == null)
                    {
                        throw new Exception("not found");
                    }
                return debt;
            }
            
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var debt = _db.Debts.Find(id);

                if (debt == null)
                {
                    throw new Exception("not found");
                }

                _db.Debts.Remove(debt);
                _db.SaveChanges();
            }
        }

        public List<Debts> GetList()
        {
            lock (Look)
            {
                List<Debts> result = null;
                    result = _db.Debts.ToList();

                return result;
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
