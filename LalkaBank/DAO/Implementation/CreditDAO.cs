using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implementation
{
    // ReSharper disable once InconsistentNaming
    public class CreditDAO : ICreditDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Credit credit)
        {
            lock (Look)
            {
                _db.Credits.AddOrUpdate(credit);
                _db.SaveChanges();
            }
        }

        public Credit Get(Guid id)
        {
            lock (Look)
            {
                var credit = _db.Credits.Find(id);
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
                var credit = _db.Credits.Find(id);
                if (credit != null)
                {
                    _db.Credits.Remove(credit);
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }

        public List<Credit> GetList()
        {
            lock (Look)
            {
                List<Credit> result = null;
                    result = _db.Credits.ToList();
                return result;
            }
            
        }

        public Table GetTimeTable()
        {
            lock (Look)
            {
                return _db.Table.FirstOrDefault();
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
