using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class ManagerDAO : IManagerDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Manager manager)
        {
            lock (Look)
            {
                _db.Managers.AddOrUpdate(manager);
                _db.SaveChanges();
            }
        }

        public Manager Get(Guid id)
        {
            lock (Look)
            {
                Manager manager = null;
                    manager = _db.Managers.Find(id);
                    if (manager == null)
                    {
                        throw new Exception("not found");
                    }

                return manager;
            }
           
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var manager = _db.Managers.Find(id);
                if (manager == null)
                {
                    throw new Exception("not found");
                }

                _db.Managers.Remove(manager);
                _db.SaveChanges();
            }
        }

        public List<Manager> GetList()
        {
            lock (Look)
            {
                List<Manager> result = null;
                    result = _db.Managers.ToList();

                return result;
            }
            
        }
    }
}
