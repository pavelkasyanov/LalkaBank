using System;
using System.Collections.Generic;
using System.Linq;
using Cron;
using DAO;
using DAO.Implementation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implementation
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

        public bool Create(DAO.Credit credit)
        {
            try
            {
                _creditDao.CreateOrUpdate(credit);
                _debtDao.SaveToBase();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Credit Get(Guid id)
        {
            try
            {
                return _creditDao.Get(id);
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
                _creditDao.Delete(id);
                _debtDao.SaveToBase();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DAO.Credit> GetList()
        {
            try
            {
                return _creditDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Guid? CreateCreditForRequest(Guid requestId)
        {
            try
            {
                var request = _requestDao.Get(requestId);
                if (request == null)
                {
                    return null;
                }

                var debts = new Debts()
                {
                    Id = Guid.NewGuid(),
                    Debt = 0
                };
                _debtDao.CreateOrUpdate(debts);

                //startSum - cумма запрошеная пользователем
                int allSum = 0;
                //TODO
                var payMounth = (int)((request.StartSum + (request.StartSum * request.CreditTypes.Percent)) / request.CreditTypes.PayCount);
                var dateStart = _creditDao.GetTimeTable().Date;

                var credit = new Credit()
                {
                    Id = Guid.NewGuid(),
                    DateStart = dateStart,
                    DateEnd = dateStart.AddMonths(request.CreditTypes.PayCount),
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
                    Status = "0",
                    RequestId = requestId
                };

                _creditDao.CreateOrUpdate(credit);

                var bankBook = new BankBook()
                {
                    Id = Guid.NewGuid(),
                    CreditId = credit.Id,
                    cache = 0
                };
                _bankBookDao.CreateOrUpdate(bankBook);

                _debtDao.SaveToBase();

                if (request.CreditTypes.CreditSubType.Abbreviation.Equals("Ann"))
                {
                    AnnuityCreadit.ProcessHistory(credit.Id);
                }
                if (request.CreditTypes.CreditSubType.Abbreviation.Equals("Grad"))
                {

                    GradedCredit.ProcessHistory(credit.Id);
                }

                request.CreditId = credit.Id;
                _requestDao.CreateOrUpdate(request);

                return credit.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Credit> GetListByPersonId(Guid personId)
        {
            return _creditDao.GetList().Where(x => x.PersonId.Equals(personId)).ToList();
        }

        public Table GetTimeTable()
        {
            return _creditDao.GetTimeTable();
        }

        private readonly ICreditDAO _creditDao;
        private readonly IRequestDAO _requestDao;
        private readonly IBankBookDAO _bankBookDao;
        private readonly IDebtDAO _debtDao;
    }
}
