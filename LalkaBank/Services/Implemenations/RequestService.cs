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
        public RequestService()
        {
            _creditTypesDao = new CreditTypesDAO();
            _messageDao = new MessageDAO();
            _requestDao = new RequestDAO();
        }

        public RequestService(IRequestDAO requestDao, ICreditTypesDAO creditTypesDao, IMessageDAO messageDao)
        {
            _requestDao = requestDao;
            _creditTypesDao = creditTypesDao;
            _messageDao = messageDao;
        }

        public void Create(Request request)
        {
            request.Id = Guid.NewGuid();

            _requestDao.CreateOrUpdate(request);
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

        public bool ConfirmRequest(Guid requestId, string msg)
        {
            var request = _requestDao.Get(requestId);
            request.Confirm = 1;
            _requestDao.CreateOrUpdate(request);

            var message = new Message
            {
                Id = Guid.NewGuid(),
                PersonId = request.PersonId,
                RequestId = requestId,
                Text = msg
            };

            _messageDao.CreateOrUpdate(message);

            return true;
        }

        public bool DiscartRequest(Guid requestId, string msg)
        {
            var request = _requestDao.Get(requestId);
            request.Confirm = 2;
            return false;
        }

        private readonly IRequestDAO _requestDao;
        private readonly ICreditTypesDAO _creditTypesDao;
        private readonly IMessageDAO _messageDao;
    }
}
