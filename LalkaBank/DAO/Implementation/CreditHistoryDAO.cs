using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interafaces;

namespace DAO.Implementation
{
    public class CreditHistoryDAO : ICreditHistoryDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(CreditHistory credit)
        {
            lock (Look)
            {
                _db.CreditHistory.AddOrUpdate(credit);
                _db.SaveChanges();
            }
        }

        public CreditHistory Get(Guid id)
        {
            lock (Look)
            {
                var credit = _db.CreditHistory.Find(id);
                if (credit == null)
                {
                    throw new Exception("not found");
                }

                return credit;
            }

        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var credit = _db.CreditHistory.Find(id);
                if (credit != null)
                {
                    _db.CreditHistory.Remove(credit);
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }

        public List<CreditHistory> GetList()
        {
            lock (Look)
            {
                List<CreditHistory> result = null;
                result = _db.CreditHistory.ToList();
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
