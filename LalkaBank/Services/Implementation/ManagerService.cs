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

        public bool Create(Manager manager)
        {
            try
            {
                _managerDao.CreateOrUpdate(manager);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Manager Get(Guid id)
        {
            try
            {
                return _managerDao.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                _managerDao.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Manager> GetList()
        {
            try
            {
                return _managerDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private readonly IManagerDAO _managerDao;
    }
}
