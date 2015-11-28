using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;
namespace Services
{
    class Debt : IDebt
    {
        public DebtsDAO debtsDAO = new DebtsDAO();
        public void Create(DAO.DebtsSet debt)
        {
            debtsDAO.Create(debt);

        }

        public DAO.DebtsSet Get(Guid id)
        {

            return debtsDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            debtsDAO.Delete(id);
        }

        public List<DAO.DebtsSet> GetList()
        {
            return debtsDAO.GetList();
        }
    }
}
