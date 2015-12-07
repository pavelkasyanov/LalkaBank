using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;

namespace Cron
{
    public class CreditCron
    {
        private System.Timers.Timer timer1;
        private readonly int _interval;
        private readonly ICreditDAO _creditDao = new CreditDAO();
        private readonly IBankBookDAO _bookDao = new BankBookDAO();
        private readonly IDebtDAO _debtDao = new DebtDAO();

        public CreditCron(int interval)
        {
            this._interval = interval;
        }

        public void OnStart()
        {

            Console.WriteLine("CreditService стартовал");

            //Создаем таймер и выставляем его параметры
            this.timer1 = new System.Timers.Timer
            {
                Enabled = true,
                Interval = _interval
            };

            //10 сек - день
            //5 минут - месяц
            //Интервал 10000мс - 10с.
            //82800000 - 23 часа
            this.timer1.Elapsed +=
             new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            this.timer1.AutoReset = true;
            this.timer1.Start();

        }

        public void OnStop()
        {
            this.timer1.Stop();
            Console.WriteLine("CreditService остановлен");

        }
        private void
        timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<Credit> openCredits = new List<Credit>(), 
                credits = _creditDao.GetList();
            /// 0- кредит открыт, 1 - кредит закрыт
            openCredits.AddRange(credits.Where(el => el.Status == "0"));

            Console.WriteLine("CreditCron Запуск...");
            List<BankBook> openList = new List<BankBook>(), 
                list = _bookDao.GetList();
            // отсеиваются счета, где кридиты закрыты
            openList.AddRange(list.Where(bankBook => openCredits.Contains(_creditDao.Get(bankBook.CreditId))));

            int i = 1;
            if (openList.Count > 0)
            {
                foreach (var el in openList)
                {
                    StartThreadForCreditType(i, el);
                    i++;
                }

                openCredits = null;
                openList = null;
            }
        }

        private void StartThreadForCreditType(int i, BankBook el)
        {
            new CerditType1_Thread(i, el);
        }
    }
}
