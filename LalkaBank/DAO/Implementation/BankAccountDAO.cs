using System;
using System.Data.Entity.Migrations;

namespace DAO.Interafaces
{
    public class BankAccountDAO : IBankAccountDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(BankAaccount credit)
        {
            lock (Look)
            {
                _db.BankAaccount.AddOrUpdate(credit);
                _db.SaveChanges();
            }
        }

        public BankAaccount Get(Guid id)
        {
            lock (Look)
            {
                var credit = _db.BankAaccount.Find(id);
                if (credit == null)
                {
                    throw new Exception("not found");
                }

                return credit;
            }
        }
    }
}