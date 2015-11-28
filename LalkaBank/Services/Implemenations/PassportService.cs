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

        public void Create(PassportSet passport)
        {
            _passportDao.Create(passport);
        }

        public PassportSet Get(Guid id)
        {
            return _passportDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _passportDao.Delete(id);
        }

        public List<PassportSet> GetList()
        {
            return _passportDao.GetList();
        }

        private readonly IPassportDAO _passportDao;
    }
}
