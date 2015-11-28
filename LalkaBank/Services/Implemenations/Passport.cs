using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;

namespace Services
{
    class Passport : IPassport
    {
        public PassportDAO passportDAO = new PassportDAO();
        public void Create(DAO.PassportSet passport)
        {
            passportDAO.Create(passport);

        }

        public DAO.PassportSet Get(Guid id)
        {

            return passportDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            passportDAO.Delete(id);
        }

        public List<DAO.PassportSet> GetList()
        {
            return passportDAO.GetList();
        }
    }
}
