using DAO;
using DAO.Implementation;
using DAO.Interafaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Cron
{
    public class CreditHandler
    {
        private Timer _timer;

        private readonly int _interval;
        
        public CreditHandler(int interval)
        {
            _interval = interval;
        }

        public void Init()
        {
            Console.WriteLine("Credit Handler: Start setting the timer");

            //Create timer and set his parametrs
            this._timer = new Timer
            {
                Enabled = true,
                Interval = _interval
            };
            _timer.Elapsed += new ElapsedEventHandler(this.TimerElapsed);
            _timer.AutoReset = true;

            Console.WriteLine("Entry Point: Default value of day time - {0} (for test only)", _interval);

            Console.WriteLine("Credit Handler: Etart setting the timer");
        }

        public void Start()
        {

            Console.WriteLine("Credit Handler: Start");
            
            Console.WriteLine("Credit Handler: Start processing life circle");

            _timer.Start();

        }

        public void Stop()
        {
            _timer.Stop();

            Console.WriteLine("Credit Handler: End processing life circle");

        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            LalkaBankDabaseModelContainer context = new LalkaBankDabaseModelContainer();

            Console.WriteLine("Credit Handler: Start processing life circle spiral");

            Console.WriteLine("Credit Handler: Start updating current model time (for test only)");

            var newDate = context.Table.First().Date.AddDays(1);
                        
            context.Table.RemoveRange(context.Table);
            context.Table.Add(new Table() { Date = newDate });
            context.SaveChanges();

            Console.WriteLine("Credit Handler: Current model time - {0} (for test only)", newDate);
            
            Console.WriteLine("Credit Handler: End updating current model time (for test only)");

            //All bank account into systems
            List<Credit> credits = context.Credits.Where(credit => credit.Status == "0").ToList();
            
            if (credits.Count > 0)
            {
                int counter = 1;

                Console.WriteLine("Credit Handler: Start proccesing credits");

                foreach (var credit in credits)
                {
                    Console.WriteLine("Credit Handler: Start proccesing {0} credit", counter);

                    StartThreadForCreditType(counter, credit);
                    counter++;
                }
            }

            credits = null;
            context.Dispose();
        }

        private void StartThreadForCreditType(int counter, Credit credit)
        {
            new AnnuityСreditThread(counter, credit);
        }
    }
}
