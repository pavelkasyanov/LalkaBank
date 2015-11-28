﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PaymentDAO : IPaymentDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(PaymentsSet payment)
        {
            _db.PaymentsSets.Add(payment);
            _db.SaveChanges();
        }

        public PaymentsSet Get(Guid id)
        {
            var payment = _db.PaymentsSets.Find(id);
            if (payment == null) { throw new Exception("not found"); }

            return payment;
        }

        public void Delete(Guid id)
        {
            var payment = _db.PaymentsSets.Find(id);
            if (payment == null) { throw new Exception("not found"); }

            _db.PaymentsSets.Remove(payment);
            _db.SaveChanges();
        }

        public List<PaymentsSet> GetList()
        {
            return _db.PaymentsSets.ToList();
        }
    }
}
