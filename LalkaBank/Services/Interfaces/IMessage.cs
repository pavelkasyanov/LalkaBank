using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Services
{
    interface IMessage
    {
        void Create(MessageSet message);
        MessageSet Get(Guid id);
        void Delete(Guid id);
        List<MessageSet> GetList();
    }
}
