using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface IBankAccountDAO
    {
        void CreateOrUpdate(BankAaccount credit);
        BankAaccount Get(Guid id);
    }
}
