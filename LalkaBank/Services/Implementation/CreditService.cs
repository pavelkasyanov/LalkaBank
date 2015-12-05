using System;
using System.Collections.Generic;
using DAO;
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

        public CreditService(ICreditDAO creditDao, IRequestDAO requestDao)
        {
            _creditDao = creditDao;
            _requestDao = requestDao;
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
            //startSum - cумма запрошеная пользователем
            int allSum = 0;
            //TODO
            var payMounth = (int) (request.StartSum * request.CreditTypes.Percent / request.CreditTypes.PayCount);

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
                Status = "open"
            };

            _creditDao.CreateOrUpdate(credit);

            return true;
        }

        private readonly ICreditDAO _creditDao;
        private readonly IRequestDAO _requestDao;
    }
}
