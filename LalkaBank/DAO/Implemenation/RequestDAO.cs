using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class RequestDAO : IRequestDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(Request request)
        {
            _db.Requests.Add(request);
            _db.SaveChanges();
        }

        public Request Get(Guid id)
        {
            var request = _db.Requests.Find(id);
            if (request == null) { throw new Exception("not found"); }

            return request;
        }

        public void Delete(Guid id)
        {
            var request = _db.Requests.Find(id);
            if (request == null) { throw new Exception("not found"); }

            _db.Requests.Remove(request);
            _db.SaveChanges();
        }

        public List<Request> GetList()
        {
            return _db.Requests.ToList();
        }
    }
}
