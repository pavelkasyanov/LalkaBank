using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace Services
{
    public interface ICreditTypesService
    {
        void Create(CreditTypesSet creditTypes);

        CreditTypesSet Get(Guid id);

        void Delete(Guid id);

        List<CreditTypesSet> GetList();

    }
}
