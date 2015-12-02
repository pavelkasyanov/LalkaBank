using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class PaymentService : IPaymentService
    {
        [Obsolete("use other constructor")]
        public PaymentService()
        {
            _paymentDao = new PaymentDAO();
        }

        public PaymentService(IPaymentDAO paymentDao)
        {
            _paymentDao = paymentDao;
        }

        public void Create(Payments payment)
        {
            _paymentDao.CreateOrUpdate(payment);
        }

        public Payments Get(Guid id)
        {
            return _paymentDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _paymentDao.Delete(id);
        }

        public List<Payments> GetList()
        {
            return _paymentDao.GetList();
        }

        private readonly IPaymentDAO _paymentDao;
    }
}
