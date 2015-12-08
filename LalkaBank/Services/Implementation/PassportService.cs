using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class PassportService : IPassportService
    {
        [Obsolete("use other constructor")]
        public PassportService()
        {
            _passportDao = new PassportDAO();
        }

        public PassportService(IPassportDAO passportDao)
        {
            _passportDao = passportDao;
        }

        public bool Create(Passport passport)
        {
            try
            {
                _passportDao.CreateOrUpdate(passport);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Passport Get(Guid id)
        {
            try
            {
                return _passportDao.Get(id);
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
                _passportDao.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Passport> GetList()
        {
            try
            {
                return _passportDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private readonly IPassportDAO _passportDao;
    }
}
