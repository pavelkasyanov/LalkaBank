using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;
namespace Services
{
    class CreditTypes : ICreditTypes
    {
        public CreditTypesDAO credit_typesDAO = new CreditTypesDAO();
        public void Create(DAO.CreditTypesSet credit_types)
        {
            credit_typesDAO.Create(credit_types);

        }

        public DAO.CreditTypesSet Get(Guid id)
        {

            return credit_typesDAO.GetById(id);
        }

        public void Delete(Guid id)
        {
            credit_typesDAO.Delete(id);
        }

        public List<DAO.CreditTypesSet> GetList()
        {
            return credit_typesDAO.GetList();
        }
    }
}
