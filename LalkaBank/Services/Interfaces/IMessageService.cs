using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IMessageService
    {
        void Create(Message message);

        Message Get(Guid id);

        void Delete(Guid id);

        List<Message> GetList();

        List<Message> GetFromUser(Guid userId);
    }
}
