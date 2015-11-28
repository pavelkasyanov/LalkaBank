using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Interafaces;
using DAO.Implemenation;
namespace Services
{
    class Request : IRequest
    {
      public  RequestDAO requestDAO = new RequestDAO();
        public void Create(DAO.RequestSet request)
        {
            requestDAO.Create(request);

        }

        public DAO.RequestSet Get(Guid id)
        {

            return requestDAO.Get(id);
        }

        public void Delete(Guid id)
        {
            requestDAO.Delete(id);
        }

        public List<DAO.RequestSet> GetList()
        {
            return requestDAO.GetList();
        }
    }
}
