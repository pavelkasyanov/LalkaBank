using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class MessageDAO : IMessageDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public void CreateOrUpdate(Message message)
        {
            _db.Messages.AddOrUpdate(message);
            _db.SaveChanges();
        }

        public Message Get(Guid id)
        {
            var message = _db.Messages.Find(id);
            if (message == null) { throw new Exception("not found"); }

            return message;
        }

        public void Delete(Guid id)
        {
            var message = _db.Messages.Find(id);
            if (message == null) { throw new Exception("not found"); }
            
            _db.Messages.Remove(message);
            _db.SaveChanges();
        }

        public List<Message> GetList()
        {
            return _db.Messages.ToList();
        }
    }
}
