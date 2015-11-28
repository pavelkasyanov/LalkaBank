using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;

namespace Services.Implemenations
{
    public class RequestService : IRequestService
    {
        [Obsolete("use other constructor")]
        public RequestService()
        {
            _requestDao = new RequestDAO();
        }

        public RequestService(IRequestDAO requestDao)
        {
            _requestDao = requestDao;
        }

        public void Create(RequestSet request)
        {
            _requestDao.Create(request);
        }

        public RequestSet Get(Guid id)
        {
            return _requestDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _requestDao.Delete(id);
        }

        public List<RequestSet> GetList()
        {
            return _requestDao.GetList();
        }

        private readonly IRequestDAO _requestDao;
    }
}
