using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implementation
{
    // ReSharper disable once InconsistentNaming
    public class PaymentDAO : IPaymentDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Payments payment)
        {
            lock (Look)
            {
                _db.Payments.AddOrUpdate(payment);
                _db.SaveChanges();
            }
        }

        public Payments Get(Guid id)
        {
            lock (Look)
            {
                var payment = _db.Payments.Find(id);
                if (payment == null)
                {
                    throw new Exception("not found");
                }

                return payment;
            }  
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var payment = _db.Payments.FindAsync(id).Result;
                if (payment == null)
                {
                    throw new Exception("not found");
                }

                _db.Payments.Remove(payment);
                _db.SaveChanges();
            }
        }

        public List<Payments> GetList()
        {
            lock (Look)
            {
                return _db.Payments.ToList();
            }
        }
    }
}
