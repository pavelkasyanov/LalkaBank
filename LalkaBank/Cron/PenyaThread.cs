using System;
using System.Diagnostics;
using System.Threading;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;

namespace Cron
{
    public class PenyaThread
    {
        private readonly int _number;
        private readonly IDebtDAO _debtDao = new DebtDAO();

        public PenyaThread(int i, Credit obj)
        {
            _number = i;
            var thread = new Thread(Process)
            {
                IsBackground = true
            };

            thread.Start(obj);
        }

        public void Process(Object obj)
        {
            Credit credit = (Credit) obj;

            Console.WriteLine("PenyaCron: {0} work", _number);
            var debt = _debtDao.Get(credit.DebtsId.Value);
            if (debt != null)
            {
                //debt.Debt = (short) (debt.Debt*100*(credit.Penya));
                debt.Debt = (short)(debt.Debt * credit.Penya + debt.Debt);
                _debtDao.CreateOrUpdate(debt);
                if (debt.Debt != 0)
                {
                    Console.WriteLine("PenyaCron: debt={0}", debt.Debt);
                }
            }

            /*
           * проверять есть ли строка в таблице долга и пока она есть
           * - умножать её на процент указанный в кредите
            */
        }
    }
}