using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IMessageDAO
    {
         void Create(Message message);
         Message Get(Guid id);
         void Delete(Guid id);
         List<Message> GetList();
    }
}
