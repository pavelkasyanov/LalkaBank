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
        public RequestService(IBankAccountDAO bankAccountDao, ICreditService creditService)
        {
            _bankAccountDao = bankAccountDao;
            _creditService = creditService;
            _creditTypesDao = new CreditTypesDAO();
            _messageDao = new MessageDAO();
            _requestDao = new RequestDAO();
        }

        public RequestService(IRequestDAO requestDao, 
            ICreditTypesDAO creditTypesDao, 
            IMessageDAO messageDao, 
            IBankAccountDAO bankAccountDao, 
            ICreditService creditService)
        {
            _requestDao = requestDao;
            _creditTypesDao = creditTypesDao;
            _messageDao = messageDao;
            _bankAccountDao = bankAccountDao;
            _creditService = creditService;
        }

        public bool Create(Request request)
        {
            try
            {
                request.Id = Guid.NewGuid();

                _requestDao.CreateOrUpdate(request);

                _requestDao.SaveToBase();

                return true;
            }
            catch (Exception)
            {
                //throw;
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

                _requestDao.SaveToBase();

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

                request.ManagerId = managerId;
                _requestDao.CreateOrUpdate(request);

                var creditId = _creditService.CreateCreditForRequest(requestId);
                if (!creditId.HasValue)
                {
                    return false;
                }

                request.CreditId = creditId.Value;
                request.Confirm = 1;

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

                _requestDao.SaveToBase();
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

                _requestDao.SaveToBase();

               var t =  _bankAccountDao.Get();
                t.Amount += request.StartSum;
                _bankAccountDao.CreateOrUpdate(t);

                return true;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }

        private readonly IRequestDAO _requestDao;
        private readonly ICreditTypesDAO _creditTypesDao;
        private readonly IMessageDAO _messageDao;
        private readonly IBankAccountDAO _bankAccountDao;

        private readonly ICreditService _creditService;
    }
}
