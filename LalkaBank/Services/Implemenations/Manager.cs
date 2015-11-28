using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;

namespace Services
{
    class Manager : IManager
    {
        public ManagerDAO managerDAO = new ManagerDAO();
        public void Create(DAO.ManagerSet manager)
        {
            managerDAO.Create(manager);

        }

        public DAO.ManagerSet Get(Guid id)
        {

            return managerDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            managerDAO.Delete(id);
        }

        public List<DAO.ManagerSet> GetList()
        {
            return managerDAO.GetList();
        }
    }
}
