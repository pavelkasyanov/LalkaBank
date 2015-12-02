using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IMessageDAO
    {
        void CreateOrUpdate(Message message);

        Message Get(Guid id);

        void Delete(Guid id);

        List<Message> GetList();
    }
}
