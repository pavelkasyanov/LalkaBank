using System;
using System.Collections.Generic;
using System.Linq;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class RequestService : IRequestService
    {
        [Obsolete("use other constructor")]
        public RequestService(ICreditTypesDAO creditTypesDao)
        {
            _creditTypesDao = creditTypesDao;
            _requestDao = new RequestDAO();
        }

        public RequestService(IRequestDAO requestDao, ICreditTypesDAO creditTypesDao)
        {
            _requestDao = requestDao;
            _creditTypesDao = creditTypesDao;
        }

        public void Create(Request request)
        {
            request.Id = Guid.NewGuid();

            _requestDao.Create(request);
        }

        public Request Get(Guid id)
        {
            return _requestDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _requestDao.Delete(id);
        }

        public List<Request> GetList()
        {
            return _requestDao.GetList();
        }

        public List<Request> GetListByPersonId(Guid personId)
        {
            return  GetList().Where(x => x.PersonId.Equals(personId)).ToList();
        }

        public List<CreditType> GetCreditTypes()
        {
            return _creditTypesDao.GetList();
        }

        private readonly IRequestDAO _requestDao;
        private readonly ICreditTypesDAO _creditTypesDao;
    }
}
