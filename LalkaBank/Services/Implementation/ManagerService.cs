using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

                _managerDao.SaveToBase();

                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
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

                _managerDao.SaveToBase();

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

        public bool IsManagerRegister(Guid managerId)
        {
            return _managerDao.Get(managerId) != null;
        }

        private readonly IManagerDAO _managerDao;
    }
}
