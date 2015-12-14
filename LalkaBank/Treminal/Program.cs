using System;
using System.Collections.Generic;
using System.Linq;
using DAO;
using System.IO;

namespace Treminal
{
    public class Program
    {
        public static bool Validator(string key)
        {
            return key.All(char.IsDigit);
        }

        static void Process()
        {
            var context = new LalkaBankDabaseModelContainer();

            Console.WriteLine("Terminal: Enter Login");
            string name = Console.ReadLine();

            if (context.Persons.Any(person => person.Login == name) == false)
            {
                Console.WriteLine("Terminal: User with such login does not exist");
                return;
            }

            Console.WriteLine("Terminal: Active user credits");

            List<Credit> creditList = context.Credits.Where(credit => credit.Status == "0" && credit.Persons.Login == name).ToList();

            if (creditList.Count == 0)
                Console.WriteLine("Terminal: Active user credits do not exist");
            else
            {
                Console.WriteLine("Terminal: Active credits numbers");

                int counter = 1;
                foreach (var credit in creditList)
                {
                    Console.WriteLine("{0}. Credit with number {1}", counter, credit.Number);
                    counter++;
                }

                Console.WriteLine("Terminal: Press 'P' to pay, other - for exit");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        {
                            Console.WriteLine("Terminal: Enter credit's number");

                            var key1 = Console.ReadLine();

                            int number;
                            int.TryParse(key1, out number);

                            Credit credit = context.Credits.FirstOrDefault(x => x.Number == number);
                            if (credit == null)
                            {
                                Console.WriteLine("Terminal: Wrong credit number");
                            }
                            else
                            {
                                Console.WriteLine("Terminal: Enter the amount for payment");

                                string key2 = Console.ReadLine();

                                if (Validator(key2) == false)
                                {
                                    Console.WriteLine("Terminal: Wrong credit amount");
                                    return;
                                }

                                int pay = 0;
                                int.TryParse(key2, out pay);

                                Payments payment = new Payments
                                {
                                    Id = Guid.NewGuid(),
                                    CreditId = credit.Id,
                                    Payment = key2,
                                    Time = context.Table.FirstOrDefault().Date
                                };

                                context.Payments.Add(payment);

                                BankBook book = credit.BankBooks.FirstOrDefault(x => x.CreditId == credit.Id);

                                book.cache = (long)(book.cache + pay);

                                Console.WriteLine("Terminal: Payment - {0}", payment.Payment);

                            }
                            break;
                        }
                }
            }

            context.SaveChanges();
            context.Dispose();
        }

        static void Main(string[] args)
        {
            try
            {
                //TestGradedHistory();
                //TestAnnuityHistory();
                Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Detected a problem connecting to the database. Please restart the application.");
                var name = "Terminal - Connection trace: " + DateTime.Now;
                File.Create(name);
                File.AppendAllText(name, ex.StackTrace);
            }
        }
    }
}
