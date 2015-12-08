using System;
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

        public bool Create(Message message)
        {
            try
            {
                _messageDao.CreateOrUpdate(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Message Get(Guid id)
        {
            try
            {
                return _messageDao.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                _messageDao.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Message> GetList()
        {
            try
            {
                return _messageDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Message> GetFromUser(Guid userId)
        {
            try
            {
                return _messageDao.GetList().Where(msg => msg.PersonId == userId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Message> GetFromManager(Guid managerId)
        {
            try
            {
                return _messageDao.GetList().Where(msg => msg.ManagerId == managerId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private readonly IMessageDAO _messageDao;
    }
}
