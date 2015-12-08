using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class DebtService : IDebtService
    {
        [Obsolete("use other constructor")]
        public DebtService()
        {
            _debtDao = new DebtDAO();
        }

        public DebtService(IDebtDAO debtDao)
        {
            _debtDao = debtDao;
        }

        public bool Create(Debts debt)
        {
            try
            {
                _debtDao.CreateOrUpdate(debt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Debts Get(Guid id)
        {
            try
            {
                return _debtDao.Get(id);
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
                _debtDao.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Debts> GetList()
        {
            try
            {
                return _debtDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private readonly IDebtDAO _debtDao;
    }
}
