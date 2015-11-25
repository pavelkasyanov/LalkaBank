using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    interface IMessageDAO
    {
         void Create(MessageSet message);
        MessageSet Get(Guid id);
         void Delete(Guid id);
         List<MessageSet> GetList();
    }
}
