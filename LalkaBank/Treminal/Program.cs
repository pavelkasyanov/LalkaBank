using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;

namespace Treminal
{
    public class Program
    {
        public static bool Validator(string key)
        {
            return key.All(char.IsDigit);
        }

        static void Main(string[] args)
        {
            ICreditDAO creditDao = new CreditDAO();
            IDebtDAO debtsDao = new DebtDAO();
            IPaymentDAO paymentDao = new PaymentDAO();
            IBankBookDAO bookDao = new BankBookDAO();
            IPersonDAO personDao = new PersonDAO();

            Console.WriteLine("Enter Login");
            string name = Console.ReadLine();

            Console.WriteLine("Enter password");
            //string pass = Console.ReadLine();


            // проверить существование пользователя!!
            // получить список активных кредитов
            // проверять статус

            if (personDao.GetList().Find(x => x.Login.Equals(name)) == null)
            {
                return;
            }

            Console.WriteLine("Active credits");
            List<Credit> creditList = creditDao.GetList()
                            .Where(x => x.Status.Equals("0") && x.Persons.Login.Equals(name)).ToList();
            if (creditList.Count == 0)
                Console.WriteLine("NO found active credits");
            else
            {
                foreach (var el in creditList)
                {
                    Console.WriteLine("{0},{1}", el.Id, el.PayMounth);//all sum - остаточная цена
                }


                Console.WriteLine("press P to pay, Q to exit");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.P:
                        {
                            Console.WriteLine("Enter credit's number");
                            var key1 = Console.ReadLine();
                            int number = 0;
                           int.TryParse(key1, out number);
                            Credit credit = creditDao.GetList().FirstOrDefault(x => x.Number == number);
                            if (credit == null)
                                Console.WriteLine("Error");
                            else
                            {
                                Console.WriteLine("input money");
                                string key2 = Console.ReadLine();
                                if (Validator(key2) == false) // проверка ввода
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    return;
                                }
                                int pay = 0;
                                int.TryParse(key2, out pay);
                                Payments payment = new Payments
                                {
                                    CreditId = credit.Id,
                                    Payment = key2,
                                    Time = DateTime.Now
                                };

                                paymentDao.CreateOrUpdate(payment);
                                BankBook book = credit.BankBooks.FirstOrDefault(x => x.CreditId.Equals(credit.Id));
                                //BankBook book = new BankBook();
                                //List<BankBook> set = bookDao.GetList();
                                //foreach (var el in set)
                                //{
                                //    if (el.CreditId.Equals(credit.Id))
                                //    {
                                //        book = el;
                                //        break;
                                //    }

                                //}
                                //проверка есть ли непогашенный долг
                                Debts debt = debtsDao.Get(credit.DebtsId.Value);
                                if (debt == null) // долгов нет
                                {

                                    book.cache = (Int16)(book.cache + pay);
                                    bookDao.CreateOrUpdate(book);
                                    Console.WriteLine("Платеж составил {0}", payment.Payment);
                                    Console.WriteLine("Поступило на счет {0}", book.cache);
                                }
                                else
                                {
                                    if (pay - debt.Debt > 0)// если оплата полностью гасит долг
                                    {
                                        book.cache = (Int16)(book.cache + (pay - debt.Debt));
                                        bookDao.CreateOrUpdate(book);
                                        Console.WriteLine("Платеж составил {0}", payment.Payment);
                                        Console.WriteLine("Поступило на счет {0}", book.cache);
                                    }
                                    else
                                    {
                                        debt.Debt = (Int16)(debt.Debt - pay);
                                        debtsDao.CreateOrUpdate(debt);
                                        Console.WriteLine("Платеж составил {0}", payment.Payment);
                                    }
                                }
                                break;
                            }
                            break;
                        }
                    case ConsoleKey.Q:
                        {
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
                            Console.WriteLine("Goodbuy");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
