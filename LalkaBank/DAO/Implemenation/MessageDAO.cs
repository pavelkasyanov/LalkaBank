using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    class MessageDAO : IMessageDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void Create(MessageSet message)
        {
            _db.MessageSets.Add(message);
            _db.SaveChanges();
        }

        public MessageSet Get(Guid id)
        {
            MessageSet message = _db.MessageSets.Find(id);
            if (message == null)
                throw new Exception("not found");
            else
                return message;
        }

        public void Delete(Guid id)
        {
            MessageSet message = _db.MessageSets.Find(id);
            if (message == null)
                throw new Exception("not found");
            else
            {
                _db.MessageSets.Remove(message);
                _db.SaveChanges();
            }

        }

        public List<MessageSet> GetList()
        {
            return _db.MessageSets.ToList();
        }
    }
}
