using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;
namespace Services
{
    class Credit :ICredit
    {
        public CreditDAO creditDAO = new CreditDAO();
        public void Create(DAO.CreditSet credit)
        {
            creditDAO.Create(credit);

        }

        public DAO.CreditSet Get(Guid id)
        {

            return creditDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            creditDAO.Delete(id);
        }

        public List<DAO.CreditSet> GetList()
        {
            return creditDAO.GetList();
        }
    }
}
