using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Services.Interfaces
{
    public interface IBankAccountService
    {
        void CreateOrUpdate(BankAaccount credit);
        BankAaccount Get(Guid id);

        BankAaccount Get();
    }
}
