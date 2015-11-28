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
            _debtsDao = new DebtsDAO();
        }

        public DebtService(IDebtsDAO debtsDao)
        {
            _debtsDao = debtsDao;
        }

        public void Create(DebtsSet debt)
        {
            _debtsDao.Create(debt);
        }

        public DebtsSet Get(Guid id)
        {
            return _debtsDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _debtsDao.Delete(id);
        }

        public List<DebtsSet> GetList()
        {
            return _debtsDao.GetList();
        }

        private readonly IDebtsDAO _debtsDao;
    }
}
