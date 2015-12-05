using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class BankBookService :IBankBookService
    {
        [Obsolete("use other constructor")]
        public BankBookService()
        {
            _bankBookDao = new BankBookDAO();
        }

        public BankBookService(IBankBookDAO bankBookDao)
        {
            _bankBookDao = bankBookDao;
        }

        public void Create(BankBook book)
        {
            _bankBookDao.CreateOrUpdate(book);

        }

        public BankBook Get(Guid id)
        {
            return _bankBookDao.Get(id);
        }

        public void Delete(Guid id)
        {
            _bankBookDao.Delete(id);
        }

        public List<BankBook> GetList()
        {
            return _bankBookDao.GetList();
        }


        public void Update(BankBook book)
        {
            _bankBookDao.Update(book);
        }

        private readonly IBankBookDAO _bankBookDao;
    }
}
