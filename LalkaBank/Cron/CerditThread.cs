using System;
using System.Diagnostics;
using System.Threading;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;

namespace Cron
{
    internal class CerditThread
    {
        private readonly int _number;

        private readonly ICreditDAO _creditDao = new CreditDAO();
        private readonly IDebtDAO _debtDao = new DebtDAO();
        private readonly IBankBookDAO _bookDao = new BankBookDAO();

        private static readonly Mutex _mut = new Mutex();

        public CerditThread(int i, Object el)
        {
            _number = i;
            var thread = new Thread(Process);
            thread.Start(el);
        }

        public void Process(Object obj)
        {
            if (_mut.WaitOne())
            {
                var bankBook = (BankBook) obj;

                Console.WriteLine("поток CerditThread {0} работает", this._number);

                var credit = _creditDao.Get(bankBook.CreditId);
                Console.WriteLine("{0}", credit.AllSum);

                bankBook.cache = (short) (bankBook.cache - credit.PayMounth);

                if (_creditDao.Get(bankBook.CreditId).PayCount == 0)
                    if ((short) (_debtDao.Get(credit.DebtsId.Value).Debt) == (0))
                    {
                        Console.WriteLine("Время кредита истекло, долг = 0, кредит закрыть");
                        credit.Status = "1";
                        _creditDao.CreateOrUpdate(credit);
                        _mut.ReleaseMutex();
                        return;
                    } // если кредит закрыт и долг равен 0
                    else
                    {
                        Console.WriteLine("Время кредита истекло, долг != 0, кредит открыт");
                        _mut.ReleaseMutex();
                        return;
                    }
                if (credit.PayCount != 0) // кредит открыт
                {

                    if (bankBook.cache <= 0)
                    {
                        Debts debt = _debtDao.Get(credit.DebtsId.Value);
                        if (debt != null)
                        {
                            debt.Debt = (short) (debt.Debt + (-1)*bankBook.cache);
                            bankBook.cache = 0;
                            _bookDao.CreateOrUpdate(bankBook);
                            _debtDao.CreateOrUpdate(debt);

                        }
                        else
                        {
                            debt = new Debts
                            {
                                Id = Guid.NewGuid(),
                                Debt = (short) ((-1)*bankBook.cache)
                            };
                            bankBook.cache = 0;
                            _bookDao.CreateOrUpdate(bankBook);
                            credit.DebtsId = debt.Id;

                            _creditDao.CreateOrUpdate(credit);
                            _debtDao.CreateOrUpdate(debt);
                        }

                        credit.PayCount--;
                        _creditDao.CreateOrUpdate(credit);
                        if (credit.PayCount == 0)
                        {
                            if ((short) (_debtDao.Get(credit.DebtsId.Value).Debt) == (0))
                            {
                                Console.WriteLine("Время кредита истекло, долг = 0, кредит закрыть");
                                credit.Status = "1";
                                _creditDao.CreateOrUpdate(credit);
                            } // если кредит закрыт и долг равен 0
                            else
                            {
                                Console.WriteLine("Время кредита истекло, долг != 0({0}), кредит открыт", debt.Debt);
                                //Console.WriteLine("долг != 0, кредит открыт");
                            }

                        }
                    }
                }
            }
            _mut.ReleaseMutex();
        }
    }
}