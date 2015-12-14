using System;
using System.Collections.Generic;
using DAO;
using DAO.Implemenation;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class CreditTypesService : ICreditTypesService
    {
        [Obsolete("use other constructor")]
        public CreditTypesService()
        {
            _creditTypesDao = new CreditTypesDAO();
        }

        public CreditTypesService(CreditTypesDAO creditTypesDao)
        {
            _creditTypesDao = creditTypesDao;
        }

        public bool Create(CreditType creditTypes)
        {
            try
            {
                _creditTypesDao.CreateOrUpdate(creditTypes);
                _creditTypesDao.SaveToBase();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CreditType Get(Guid id)
        {
            try
            {
                return _creditTypesDao.GetById(id);
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
                _creditTypesDao.Delete(id);
                _creditTypesDao.SaveToBase();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CreditType> GetList()
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

        public List<CreditSubType> GetCreditSubTypes()
        {
            return _creditTypesDao.GetCreditSubTypes();
        }

        private readonly CreditTypesDAO _creditTypesDao;
    }
}
