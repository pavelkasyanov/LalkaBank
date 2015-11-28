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

        public void Create(DebtsSet debt)
        {
            _debtDao.Create(debt);
        }

        public DebtsSet Get(Guid id)
        {
            return _debtDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _debtDao.Delete(id);
        }

        public List<DebtsSet> GetList()
        {
            return _debtDao.GetList();
        }

        private readonly IDebtDAO _debtDao;
    }
}
