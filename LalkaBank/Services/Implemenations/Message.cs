using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;

namespace Services
{
    class Message : IMessage
    {
        public MessageDAO messageDAO = new MessageDAO();
        public void Create(DAO.MessageSet message)
        {
            messageDAO.Create(message);

        }

        public DAO.MessageSet Get(Guid id)
        {

            return messageDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            messageDAO.Delete(id);
        }

        public List<DAO.MessageSet> GetList()
        {
            return messageDAO.GetList();
        }
    }
}
