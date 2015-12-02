﻿using System;
using System.Collections.Generic;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IPaymentDAO
    {
        void Create(Payments payment);

        Payments Get(Guid id);

        void Delete(Guid id);

        List<Payments> GetList();
    }
}
