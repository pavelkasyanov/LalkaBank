using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAO;

namespace Cron
{
    class MyThread
    {
        Thread thread;
        private int number;

        public MyThread(int i, Object obj)
        {
            number = i;
            thread = new Thread(Process);
            thread.Start(obj);


        }
        public void Process(Object obj)
        {
            Payments test = (Payments)obj;
            Console.WriteLine("поток {0} работает", this.number);

            Console.WriteLine("{0} руб., {1} ID Credit", test.Payment, test.CreditId);

        }
    }
}
