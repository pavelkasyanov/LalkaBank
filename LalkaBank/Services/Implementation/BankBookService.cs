using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
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

        public bool Create(BankBook book)
        {
            try
            {
                _bankBookDao.CreateOrUpdate(book);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BankBook Get(Guid id)
        {
            try
            {
                return _bankBookDao.Get(id);
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
                _bankBookDao.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BankBook> GetList()
        {
            try
            {
                return _bankBookDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }

        }


        public bool Update(BankBook book)
        {
            try
            {
                _bankBookDao.Update(book);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private readonly IBankBookDAO _bankBookDao;
    }
}
