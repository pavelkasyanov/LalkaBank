﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class CreditTypesDAO : ICreditTypesDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(CreditTypesSet creditType)
        {
            _db.CreditTypesSets.Add(creditType);
            _db.SaveChanges();
        }

        public CreditTypesSet GetById(Guid id)
        {
            var creditType = _db.CreditTypesSets.Find(id);
            if (creditType == null)
                throw new Exception("not found");
            else
                return creditType;
        }

        public void Delete(Guid id)
        {
            var creditType = _db.CreditTypesSets.Find(id);
            if (creditType == null)
                throw new Exception("not found");
            else
            {
                _db.CreditTypesSets.Remove(creditType);
                _db.SaveChanges();
            }

        }

        public List<CreditTypesSet> GetList()
        {
            return _db.CreditTypesSets.ToList();
        }
    }
}
