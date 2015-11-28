using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Services
{
    interface IPayment
    {
        void Create(PaymentsSet payment);
        PaymentsSet Get(Guid id);
        void Delete(Guid id);
        List<PaymentsSet> GetList();
    }
}
