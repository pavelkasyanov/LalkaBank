using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class MessageService : IMessageService
    {
        [Obsolete("use other constructor")]
        public MessageService()
        {
            _messageDao = new MessageDAO();
        }

        public MessageService(IMessageDAO messageDao)
        {
            _messageDao = messageDao;
        }

        public void Create(MessageSet message)
        {
            _messageDao.Create(message);
        }

        public MessageSet Get(Guid id)
        {
            return _messageDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _messageDao.Delete(id);
        }

        public List<MessageSet> GetList()
        {
            return _messageDao.GetList();
        }

        private readonly IMessageDAO _messageDao;
    }
}
