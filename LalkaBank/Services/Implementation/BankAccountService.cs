using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountDAO _accountDao;

        public BankAccountService(IBankAccountDAO accountDao)
        {
            _accountDao = accountDao;
        }

        public void CreateOrUpdate(BankAaccount credit)
        {
            _accountDao.CreateOrUpdate(credit);
        }

        public BankAaccount Get(Guid id)
        {
            return _accountDao.Get(id);
        }

        public BankAaccount Get()
        {
            return _accountDao.Get();
        }
    }
}
