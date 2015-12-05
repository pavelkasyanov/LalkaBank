﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(Message message)
        {
            _messageDao.CreateOrUpdate(message);
        }

        public Message Get(Guid id)
        {
            return _messageDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _messageDao.Delete(id);
        }

        public List<Message> GetList()
        {
            return _messageDao.GetList();
        }

        public List<Message> GetFromUser(Guid userId)
        {
            return _messageDao.GetList().Where(msg => msg.PersonId == userId).ToList();
        }

        public List<Message> GetFromManager(Guid managerId)
        {
            return _messageDao.GetList().Where(msg => msg.ManagerId == managerId).ToList();
        }

        private readonly IMessageDAO _messageDao;
    }
}
