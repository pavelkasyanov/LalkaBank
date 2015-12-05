using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class ManagerDAO : IManagerDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void CreateOrUpdate(Manager manager)
        {
            _db.Managers.AddOrUpdate(manager);
            _db.SaveChanges();
        }

        public Manager Get(Guid id)
        {
            var manager = _db.Managers.Find(id);
            if (manager != null) { return manager; }

            throw new Exception("not found");
        }

        public void Delete(Guid id)
        {
            var manager = _db.Managers.Find(id);
            if (manager == null) { throw new Exception("not found"); }
            
            _db.Managers.Remove(manager);
            _db.SaveChanges();
        }

        public List<Manager> GetList()
        {
            return _db.Managers.ToList();
        }
    }
}
