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
    class Cron
    {
        private System.Timers.Timer timer1;
        private int count;
        private int interval;


        public Cron(int interval)
        {
            this.interval = interval;
        }
        IPaymentDAO dao = new PaymentDAO();
        public void OnStart()
        {

            Console.WriteLine("MyFirstService стартовал");

            //Создаем таймер и выставляем его параметры
            this.timer1 = new System.Timers.Timer();
            this.timer1.Enabled = true;
            //10 сек - день
            //5 минут - месяц
            //Интервал 10000мс - 10с.
            this.timer1.Interval = interval;
            //82800000 - 23 часа
            this.timer1.Elapsed +=
             new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            this.timer1.AutoReset = true;
            this.timer1.Start();
            count = Counter();
        }

        public void OnStop()
        {
            this.timer1.Stop();
            Console.WriteLine("MyFirstService остановлен");

        }
        private void
        timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            Console.WriteLine("Cron Запуск...");
            int new_count = Counter();
            if (new_count > count)
            {
                int number = new_count - count;
                List<Payments> list = dao.GetList();
                for (int i = count; i != new_count; i++)
                {
                    Console.WriteLine("добавлена запись {0}", i - count + 1);
                    new MyThread(i - count + 1, list.ElementAt(i));
                }
                count = new_count;

            }
            else

                Console.WriteLine("Платежей не поступало");

        }
        public int Counter()
        {
            return dao.GetList().Count;

        }
    }
}
