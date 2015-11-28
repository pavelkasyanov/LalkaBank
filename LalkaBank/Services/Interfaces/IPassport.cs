using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Services
{
    interface IPassport
    {
        void Create(PassportSet passport);
        PassportSet Get(Guid id);
        void Delete(Guid id);
        List<PassportSet> GetList();
    }
}
