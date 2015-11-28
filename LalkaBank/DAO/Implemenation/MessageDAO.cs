using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class MessageDAO : IMessageDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(MessageSet message)
        {
            _db.MessageSets.Add(message);
            _db.SaveChanges();
        }

        public MessageSet Get(Guid id)
        {
            var message = _db.MessageSets.Find(id);
            if (message == null) { throw new Exception("not found"); }

            return message;
        }

        public void Delete(Guid id)
        {
            var message = _db.MessageSets.Find(id);
            if (message == null) { throw new Exception("not found"); }
            
            _db.MessageSets.Remove(message);
            _db.SaveChanges();
        }

        public List<MessageSet> GetList()
        {
            return _db.MessageSets.ToList();
        }
    }
}
