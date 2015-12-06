using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using DAO.Interafaces;

namespace DAO.Implemenation
{
    // ReSharper disable once InconsistentNaming
    public class MessageDAO : IMessageDAO
    {
        private readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();
        //private static readonly Mutex Mutex = new Mutex();
        private static readonly Object Look = new object();

        public void CreateOrUpdate(Message message)
        {
            lock (Look)
            {
                _db.Messages.AddOrUpdate(message);
                _db.SaveChanges();
            }
        }

        public Message Get(Guid id)
        {
            lock (Look)
            {
                var message = _db.Messages.Find(id);
                if (message == null)
                {
                    throw new Exception("not found");
                }
                return message;
            }
            
        }

        public void Delete(Guid id)
        {
            lock (Look)
            {
                var message = _db.Messages.Find(id);
                if (message == null)
                {
                    throw new Exception("not found");
                }

                _db.Messages.Remove(message);
                _db.SaveChanges();
            }
        }

        public List<Message> GetList()
        {
            lock (Look)
            {
                List<Message> result = null;
                result = _db.Messages.ToList();

                return result;
            }
        }
    }
}
