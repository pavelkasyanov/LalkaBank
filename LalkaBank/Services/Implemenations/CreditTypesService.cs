﻿using System;
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

        public void Create(CreditType creditTypes)
        {
            _creditTypesDao.Create(creditTypes);
        }

        public CreditType Get(Guid id)
        {
            return _creditTypesDao.GetById(id);
        }

        public void Delete(Guid id)
        {
            _creditTypesDao.Delete(id);
        }

        public List<CreditType> GetList()
        {
            return _creditTypesDao.GetList();
        }

        private readonly CreditTypesDAO _creditTypesDao;
    }
}
