using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
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

        public bool Create(Payments payment)
        {
            try
            {
                _paymentDao.CreateOrUpdate(payment);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Payments Get(Guid id)
        {
            try
            {
                return _paymentDao.Get(id);
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
                _paymentDao.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Payments> GetList()
        {
            try
            {
                return _paymentDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private readonly IPaymentDAO _paymentDao;
    }
}
