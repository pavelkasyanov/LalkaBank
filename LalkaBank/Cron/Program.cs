using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;

namespace Cron
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditDAO creditDao = new CreditDAO();
            IDebtDAO debtDao = new DebtDAO();
            IBankBookDAO bookDao = new BankBookDAO();

            var cronPenya = new PenyaCron(10000);//каждые 10 секунд
            cronPenya.OnStart();

            var cronCredit = new CreditCron(30000);//каждые 5 минут
            cronCredit.OnStart();

            var cron = new Cron(8000);
            //cron.OnStart();
            while (true)
            {
                var input = Console.ReadKey();

                if (input.Key != ConsoleKey.Escape) continue;

                Console.WriteLine("завершение работы");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(" ^_^");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(@"\^_^/");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(@"/-_-\");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("goodbay! Т_Т");
                Thread.Sleep(500);
                break;
            }

            cron.OnStop();
            cronCredit.OnStop();
            cronPenya.OnStop();

        }
    }
}
