using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    class ManagerDAO : IManagerDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(ManagerSet manager)
        {
            _db.ManagerSets.Add(manager);
            _db.SaveChanges();
        }

        public ManagerSet Get(Guid id)
        {
            ManagerSet manager = _db.ManagerSets.Find(id);
            if (manager == null)
                throw new Exception("not found");
            else
                return manager;
        }

        public void Delete(Guid id)
        {
            ManagerSet manager = _db.ManagerSets.Find(id);
            if (manager == null)
                throw new Exception("not found");
            else
            {
                _db.ManagerSets.Remove(manager);
                _db.SaveChanges();
            }

        }

        public List<ManagerSet> GetList()
        {
            return _db.ManagerSets.ToList();
        }
    }
}
