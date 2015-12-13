using DAO;
using System;
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
                //TestGradedHistory();
                //TestAnnuityHistory();
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

        private static void TestAnnuityHistory()
        {
            var guid = Guid.Parse("73256b43-3357-478f-a8ba-65a7c6903bf7");
        
            Console.WriteLine("Entry Point: Start process history for test");
        
            AnnuityCreadit.ProcessHistory(guid);
        
            Console.WriteLine("Entry Point: End process history for test");
        }

        private static void TestGradedHistory()
        {
            var guid = Guid.Parse("73256b43-3357-478f-a8ba-65a7c6903bf7");
        
            Console.WriteLine("Entry Point: Start process history for test");
        
            GradedCredit.ProcessHistory(guid);
        
            Console.WriteLine("Entry Point: End process history for test");
        }

        private static void StartProcess()
        {
            Console.WriteLine("Entry Point: Start");
            
            Console.WriteLine("Entry Point: Start installing the model time to the default value (for test only)");

            var defaultDate = DateTime.Parse("10-Dec-15 00:00:00");
            
            var context = new LalkaBankDabaseModelContainer();

            context.Table.RemoveRange(context.Table);
            context.Table.Add(new Table() { Date = defaultDate });
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
