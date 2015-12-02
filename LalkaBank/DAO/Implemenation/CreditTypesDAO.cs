using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class CreditTypesDAO : ICreditTypesDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(CreditType creditType)
        {
            _db.CreditTypes.Add(creditType);
            _db.SaveChanges();
        }

        public CreditType GetById(Guid id)
        {
            var creditType = _db.CreditTypes.Find(id);
            if (creditType == null)
                throw new Exception("not found");
            else
                return creditType;
        }

        public void Delete(Guid id)
        {
            var creditType = _db.CreditTypes.Find(id);
            if (creditType == null)
                throw new Exception("not found");
            else
            {
                _db.CreditTypes.Remove(creditType);
                _db.SaveChanges();
            }

        }

        public List<CreditType> GetList()
        {
            return _db.CreditTypes.ToList();
        }
    }
}
