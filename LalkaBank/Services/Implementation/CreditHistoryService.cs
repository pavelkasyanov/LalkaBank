using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class CreditHistoryService : ICreditHistoryService
    {
        private readonly ICreditHistoryDAO _creditHistoryDao;

        public CreditHistoryService(ICreditHistoryDAO creditHistoryDao)
        {
            _creditHistoryDao = creditHistoryDao;
        }

        public bool Create(CreditHistory creditHistory)
        {
            _creditHistoryDao.CreateOrUpdate(creditHistory);
            return true;
        }

        public CreditHistory Get(Guid id)
        {
            return _creditHistoryDao.Get(id);
        }

        public bool Delete(Guid id)
        {
            _creditHistoryDao.Delete(id);
            return true;
        }

        public List<CreditHistory> GetList()
        {
            return _creditHistoryDao.GetList();
        }

        public List<CreditHistory> GetListFromCredit(Guid creditId)
        {
            return _creditHistoryDao.GetList().Where(x => x.CreditId.Equals(creditId)).ToList();
        }
    }
}
