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
    public class PenyaCron
    {
        private System.Timers.Timer _timer1;
        private readonly int _interval;
        private readonly ICreditDAO _creditDao = new CreditDAO();
        private readonly IDebtDAO _debtDao = new DebtDAO();

        public PenyaCron(int interval)
        {
            this._interval = interval;
        }

        public void OnStart()
        {
            Console.WriteLine("PenyaService стартовал");

            //Создаем таймер и выставляем его параметры
            this._timer1 = new System.Timers.Timer
            {
                Enabled = true,
                Interval = _interval
            };
            //10 сек - день
            //5 минут - месяц
            //Интервал 10000мс - 10с.
            //82800000 - 23 часа
            this._timer1.Elapsed +=
             new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            this._timer1.AutoReset = true;
            this._timer1.Start();
        }

        public void OnStop()
        {
            this._timer1.Stop();
            Console.WriteLine("PenyaService остановлен");

        }
        private void
        timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("PenyaCron: Запуск...");
            List<Credit> list = _creditDao.GetList();
            int i = 1;
            if (list.Count > 0)
                foreach (var el in list)
                {

                    new PenyaThread(i, el);
                    i++;
                }

        }
    }
}
