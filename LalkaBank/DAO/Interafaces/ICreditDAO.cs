using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAO.Interafaces
{
    // ReSharper disable once InconsistentNaming
    public interface ICreditDAO : IContexstSave
    {
        void CreateOrUpdate(Credit credit);

        Credit Get(Guid id);

        void Delete(Guid id);

        List<Credit> GetList();

        Table GetTimeTable();

    }
}
