﻿using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface ICreditDAO
    {
        void Create(Credit credit);

        Credit Get(Guid id);

        void Delete(Guid id);

        List<Credit> GetList();

    }
}
