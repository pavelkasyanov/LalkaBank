using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class CreditService: ICreditService
    {
        [Obsolete("use other constructor")]
        public CreditService(IBankBookDAO bankBookDao, IDebtDAO debtDao)
        {
            _bankBookDao = bankBookDao;
            _debtDao = debtDao;
            _creditDao = new CreditDAO();
        }

        public CreditService(ICreditDAO creditDao, IRequestDAO requestDao, IBankBookDAO bankBookDao, IDebtDAO debtDao)
        {
            _creditDao = creditDao;
            _requestDao = requestDao;
            _bankBookDao = bankBookDao;
            _debtDao = debtDao;
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

        public bool CreateCreditForRequest(Guid requestId)
        {
            var request = _requestDao.Get(requestId);
            if (request == null)
            {
                return false;
            }

            Debts debts = new Debts()
            {
                Id = Guid.NewGuid(),
                Debt = 0
            };
            _debtDao.CreateOrUpdate(debts);

            //startSum - cумма запрошеная пользователем
            int allSum = 0;
            //TODO
            var payMounth = (int)((request.StartSum + (request.StartSum * request.CreditTypes.Percent)) / request.CreditTypes.PayCount);

            var credit = new Credit()
            {
                Id = Guid.NewGuid(),
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddMonths(request.CreditTypes.PayCount),
                Percent = request.CreditTypes.Percent,
                StartSum = request.StartSum,
                AllSum = allSum,
                PayCount = request.CreditTypes.PayCount,
                Penya = 0.04, /*belarus magic*/
                PayMounth = payMounth,
                PersonId = request.PersonId,
                ManagerId = request.ManagerId.Value,
                CreditTypeId = request.CreditTypeId,
                DebtsId = debts.Id,
                Status = "0"
            };

            _creditDao.CreateOrUpdate(credit);

            BankBook bankBook = new BankBook()
            {
                Id = Guid.NewGuid(),
                CreditId = credit.Id,
                cache = 0
            };
            _bankBookDao.CreateOrUpdate(bankBook);

            return true;
        }

        private readonly ICreditDAO _creditDao;
        private readonly IRequestDAO _requestDao;
        private readonly IBankBookDAO _bankBookDao;
        private readonly IDebtDAO _debtDao;
    }
}
