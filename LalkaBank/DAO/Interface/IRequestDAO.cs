using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    interface IRequestDAO
    {
         void Create(Request request);
         Request Get(Guid id);
         void Delete(Guid id);
         List<Request> GetList();
    }
}
