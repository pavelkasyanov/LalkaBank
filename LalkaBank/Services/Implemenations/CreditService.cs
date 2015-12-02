using System;
using System.Collections.Generic;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class CreditService: ICreditService
    {
        [Obsolete("use other constructor")]
        public CreditService()
        {
            _creditDao = new CreditDAO();
        }

        public CreditService(ICreditDAO creditDao)
        {
            _creditDao = creditDao;
        }

        public void Create(DAO.Credit credit)
        {
            _creditDao.CreateOrUpdate(credit);

        }

        public DAO.Credit Get(Guid id)
        {

            return _creditDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _creditDao.Delete(id);
        }

        public List<DAO.Credit> GetList()
        {
            return _creditDao.GetList();
        }

        private readonly ICreditDAO _creditDao;
    }
}
