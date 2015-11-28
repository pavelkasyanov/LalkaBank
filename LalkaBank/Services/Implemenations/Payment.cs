using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;
namespace Services
{
    class Payment : IPayment
    {
        public PaymentDAO paymentDAO = new PaymentDAO();
        public void Create(DAO.PaymentsSet payment)
        {
            paymentDAO.Create(payment);

        }

        public DAO.PaymentsSet Get(Guid id)
        {

            return paymentDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            paymentDAO.Delete(id);
        }

        public List<DAO.PaymentsSet> GetList()
        {
            return paymentDAO.GetList();
        }
    }
}
