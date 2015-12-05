using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class PaymentDAO : IPaymentDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void CreateOrUpdate(Payments payment)
        {
            _db.Payments.AddOrUpdate(payment);
            _db.SaveChanges();
        }

        public Payments Get(Guid id)
        {
            var payment = _db.Payments.Find(id);
            if (payment == null) { throw new Exception("not found"); }

            return payment;
        }

        public void Delete(Guid id)
        {
            var payment = _db.Payments.Find(id);
            if (payment == null) { throw new Exception("not found"); }

            _db.Payments.Remove(payment);
            _db.SaveChanges();
        }

        public List<Payments> GetList()
        {
            return _db.Payments.ToList();
        }
    }
}
