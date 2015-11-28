using System;
using System.Collections.Generic;
using DAO;

namespace Services.Interfaces
{
    public interface IMessageService
    {
        void Create(MessageSet message);

        MessageSet Get(Guid id);

        void Delete(Guid id);

        List<MessageSet> GetList();
    }
}
