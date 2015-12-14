using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class RequestDAO : IRequestDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Request request)
        {
            lock (Look)
            {
                _db.Requests.AddOrUpdate(request);
                _db.SaveChanges();
            }
        }

        public Request Get(Guid id)
        {
            lock (Look)
            {
                var request = _db.Requests.Find(id);
                if (request == null) { throw new Exception("not found"); }

                return request;
            }
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var request = _db.Requests.Find(id);
                if (request == null) { throw new Exception("not found"); }

                _db.Requests.Remove(request);
                _db.SaveChanges();
            }
        }

        public List<Request> GetList()
        {
            lock (Look)
            {
                return _db.Requests.ToList();
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
