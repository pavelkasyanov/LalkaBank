﻿using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IBankBookDAO : IContexstSave
    {
        void CreateOrUpdate(BankBook credit);
        BankBook Get(Guid id);
        void Delete(Guid id);
        void Update(BankBook id);
        List<BankBook> GetList();
    }
}
