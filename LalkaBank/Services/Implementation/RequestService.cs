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

        public bool Create(Request request)
        {
            try
            {
                request.Id = Guid.NewGuid();

                _requestDao.CreateOrUpdate(request);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Request Get(Guid id)
        {
            try
            {
                return _requestDao.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                _requestDao.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Request> GetList()
        {
            try
            {
                return _requestDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<Request> GetListByPersonId(Guid personId)
        {
            try
            {
                return GetList().Where(x => x.PersonId.Equals(personId)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CreditType> GetCreditTypes()
        {
            try
            {
                return _creditTypesDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ConfirmRequest(Guid requestId, Guid managerId, string msg)
        {
            try
            {
                //create message
                var request = _requestDao.Get(requestId);
                request.Confirm = 1;
                request.ManagerId = managerId;

                _requestDao.CreateOrUpdate(request);

                var message = new Message
                {
                    Id = Guid.NewGuid(),
                    PersonId = request.PersonId,
                    RequestId = requestId,
                    Text = msg,
                    ManagerId = managerId,

                };

                _messageDao.CreateOrUpdate(message);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DiscartRequest(Guid requestId, Guid managerId, string msg)
        {
            try
            {
                //create message
                var request = _requestDao.Get(requestId);
                request.Confirm = 2;

                _requestDao.CreateOrUpdate(request);

                var message = new Message
                {
                    Id = Guid.NewGuid(),
                    PersonId = request.PersonId,
                    RequestId = requestId,
                    Text = msg,
                    ManagerId = managerId,

                };

                _messageDao.CreateOrUpdate(message);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private readonly IRequestDAO _requestDao;
        private readonly ICreditTypesDAO _creditTypesDao;
        private readonly IMessageDAO _messageDao;
    }
}
