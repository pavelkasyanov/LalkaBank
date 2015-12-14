using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class CreditTypesDAO : ICreditTypesDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(CreditType creditType)
        {
            lock (Look)
            {
                _db.CreditTypes.AddOrUpdate(creditType);
                _db.SaveChanges();
            }
        }

        public CreditType GetById(Guid id)
        {
            lock (Look)
            {
                var creditType = _db.CreditTypes.Find(id);
                if (creditType == null)
                {
                    throw new Exception("not found");
                }

                return creditType;
            }
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var creditType = _db.CreditTypes.Find(id);
                if (creditType != null)
                {
                    _db.CreditTypes.Remove(creditType);
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }

        public List<CreditType> GetList()
        {
            lock (Look)
            {
                return _db.CreditTypes.ToList();
            }
        }

        public List<CreditSubType> GetCreditSubTypes()
        {
            lock (Look)
            {
                return _db.CreditSubType.ToList();
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
