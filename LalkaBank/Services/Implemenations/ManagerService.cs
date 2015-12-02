using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class ManagerService : IManagerService
    {
        [Obsolete("use other constructor")]
        public ManagerService()
        {
            _managerDao = new ManagerDAO();
        }
        public ManagerService(IManagerDAO managerDao)
        {
            _managerDao = managerDao;
        }

        public void Create(Manager manager)
        {
            _managerDao.Create(manager);
        }

        public Manager Get(Guid id)
        {
            return _managerDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _managerDao.Delete(id);
        }

        public List<Manager> GetList()
        {
            return _managerDao.GetList();
        }

        private readonly IManagerDAO _managerDao;
    }
}
