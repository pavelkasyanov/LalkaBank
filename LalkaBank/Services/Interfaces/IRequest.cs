using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Services
{
    interface IRequest
    {
        void Create(RequestSet request);
        RequestSet Get(Guid id);
        void Delete(Guid id);
        List<RequestSet> GetList();
    }
}
