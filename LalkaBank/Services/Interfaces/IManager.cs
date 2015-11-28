using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Services
{
    interface IManager
    {
        void Create(ManagerSet manager);
        ManagerSet Get(Guid id);
        void Delete(Guid id);
        List<ManagerSet> GetList();
    }
}
