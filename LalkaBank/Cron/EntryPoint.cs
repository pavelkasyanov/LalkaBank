using DAO;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.IO;

namespace Cron
{
    public class EntryPoint
    {
        //One day into model time equals 10 seconds (10000).
        private static int _day = 2000;

        public static void Main(string[] args)
        {
            try
            {
                StartProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Detected a problem connecting to the database. Please restart the application.");
                var name = "CRON - Connection trace: " + DateTime.Now;
                File.Create(name);
                File.AppendAllText(name, ex.StackTrace);
            }
        }

        private static void StartProcess()
        {
            //Console.WriteLine("Entry Point: Start");
            
            //Console.WriteLine("Entry Point: Start installing the model time to the default value (for test only)");

            var defaultDate = DateTime.Parse("10-Dec-15 00:00:00");
            
            var context = new LalkaBankDabaseModelContainer();

            var time = context.Table.FirstOrDefault();
            if (time == null)
            {
                context.Table.AddOrUpdate(new Table() { Date = defaultDate });
            }
            else
            {
                defaultDate = time.Date;
            }

            context.SaveChanges();
            context.Dispose();

            Console.WriteLine("Entry Point: Default value of model time - {0} (for test only)", defaultDate);

            Console.WriteLine("Entry Point: End installing the model time to the default value (for test only)");

            Console.WriteLine("Entry Point: Start Credit Handler");

            var creditHandler = new CreditHandler(_day);

            creditHandler.Init();
            creditHandler.Start();

            while (true)
            {
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Entry Point: Stop");
                    creditHandler.Stop();

                    Console.WriteLine("Entry Point: Continue? Press 'Y' for continue, any other key - for exit");

                    input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Y)
                    {
                        creditHandler.Start();
                        continue;
                    }
                    break;
                }
            }
        }
    }
}
