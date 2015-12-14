using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IMessageService
    {
        bool Create(Message message);

        Message Get(Guid id);

        bool Delete(Guid id);

        List<Message> GetList();

        List<Message> GetFromUser(Guid userId);

        List<Message> GetFromManager(Guid managerId);
    }
}
