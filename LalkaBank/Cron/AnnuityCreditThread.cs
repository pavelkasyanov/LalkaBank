using System;
using System.Diagnostics;
using System.Threading;
using DAO;
using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;
using System.Linq;
using System.Collections.Generic;

namespace Cron
{
    internal class AnnuityСreditThread
    {
        private readonly int _number;
        
        private static readonly Mutex _mut = new Mutex();

        public AnnuityСreditThread(int number, object bankBook)
        {
            _number = number;
            var thread = new Thread(Process);
            thread.Start(bankBook);
        }

        public void Process(object obj)
        {
            if (_mut.WaitOne())
            {
                var context = new LalkaBankDabaseModelContainer();

                var credit = (Credit) obj;
                
                Console.WriteLine("Annuity Credit Thread {0}: Start working", _number);
                
                List<CreditHistory> history = context.CreditHistory.Where(x => x.CreditId == credit.Id).ToList();
                history = history.OrderBy(x => x.Month).ToList();
                
                var currentDate = context.Table.First().Date;

                if (currentDate < credit.DateStart)
                {
                    Console.WriteLine("Annuity Credit Thread {0}: Credit in future? Really?", _number);

                    _mut.ReleaseMutex();

                    return;
                }

                var currentMouth = ((currentDate.Year - credit.DateStart.Year) * 12) + currentDate.Month - credit.DateStart.Month;

                if (currentDate.Day - credit.DateStart.Day > 0)
                {
                    currentMouth++;
                }

                Console.WriteLine("Annuity Credit Thread {0}: Current month for payment - {1}", _number, currentMouth);

                var previosHistory = history.Where(x => x.Month < currentMouth).ToList();
                
                decimal arrears = 0;

                Console.WriteLine("Annuity Credit Thread {0}: Count of previos months - {1}", _number, previosHistory.Count);

                for (int i = 0; i < previosHistory.Count; i++)
                {
                    Console.WriteLine("Annuity Credit Thread {0}: Start calculating arrears for the {1} month", _number, i + 1);

                    var monthArrears = previosHistory[i].TotalPayment - previosHistory[i].Paid;

                    if (monthArrears <= 0)
                    {
                        Console.WriteLine("Annuity Credit Thread {0}: Arrears on the credit does not exist", _number);
                        continue;
                    }

                    Console.WriteLine("Annuity Credit Thread {0}:  Main Arrears on the credit does exist - {1}", _number, monthArrears);

                    previosHistory[i].Arrears = monthArrears;

                    Console.WriteLine("Annuity Credit Thread {0}: Start calculating surcharge", _number);

                    var diffDay = (currentDate - credit.DateStart.AddMonths(i + 1)).Days;

                    var surchargeAlready = previosHistory[i].FinePayment;
                    Console.WriteLine("Annuity Credit Thread {0}: Days of delay - {1}", _number, diffDay);
                    Console.WriteLine("Annuity Credit Thread {0}: Already paid for surcharge - {1}", _number, surchargeAlready);

                    var surcharge = monthArrears * (decimal)0.01 * diffDay - surchargeAlready;

                    previosHistory[i].Fine = surcharge;

                    Console.WriteLine("Annuity Credit Thread {0}: Current surcharge - {1}", _number, surcharge);
                    Console.WriteLine("Annuity Credit Thread {0}: End calculating surcharge", _number);
                    Console.WriteLine("Annuity Credit Thread {0}: End calculating arrears for the {1} month", _number, i + 1);
                    
                    arrears += monthArrears + surcharge;
                }

                if (arrears > 0)
                {
                    context.Persons.Where(person => person.Credits.Any(x => x.Id == credit.Id)).FirstOrDefault().CreditHistoryIndex++;
                }
                Console.WriteLine("Annuity Credit Thread {0}: Whole arrears - {1}", _number, arrears);
                
                var bankBook = context.BankBooks.Where( account => account.CreditId == credit.Id).FirstOrDefault();

                if (bankBook.cache <= 0)
                {
                    Console.WriteLine("Annuity Credit Thread {0}: The account is empty", _number);
                    
                    context.SaveChanges();
                    context.Dispose();

                    _mut.ReleaseMutex();

                    return;
                }

                Console.WriteLine("Annuity Credit Thread {0}: The account balance - {1}", _number, bankBook.cache);
                
                if (arrears > 0)
                {
                    
                    for (int i = 0; i < previosHistory.Count; i++)
                    {
                        Console.WriteLine("Annuity Credit Thread {0}: Start calculating payments for arrears for the {1} month", _number, i + 1);
                                                
                        var surcharge = previosHistory[i].Fine;

                        if (bankBook.cache < surcharge)
                        {
                            surcharge = (int)bankBook.cache;
                            previosHistory[i].FinePayment += (int)Math.Ceiling(surcharge);
                            Console.WriteLine("Annuity Credit Thread {0}: It can be pay only - {1} for surcharge for {2} mouth (partial payment)", _number, surcharge, i + 1);
                        }

                        previosHistory[i].Fine -= surcharge;
                        bankBook.cache -= (int)Math.Ceiling(surcharge);
                                                
                        Console.WriteLine("Annuity Credit Thread {0}: Payment done, Account balance - {1}, Remaining surcharge - {2}", _number, bankBook.cache, previosHistory[i].Fine);

                        Console.WriteLine("Annuity Credit Thread {0}: End calculating payments for surcharge", _number);

                        Console.WriteLine("Annuity Credit Thread {0}: Start calculating payments for main arrears for the {1} month", _number, i + 1);

                        var mouthArrears = previosHistory[i].Arrears;

                        if (bankBook.cache < mouthArrears)
                        {
                            mouthArrears = (int)bankBook.cache;
                            Console.WriteLine("Annuity Credit Thread {0}: It can be pay only - {1} for main arrears for {2} mouth (partial payment)", _number, mouthArrears, i + 1);
                        }

                        previosHistory[i].Arrears -= mouthArrears;
                        previosHistory[i].Paid += (int)Math.Ceiling(mouthArrears);
                        bankBook.cache -= (int)Math.Ceiling(mouthArrears);

                        if (mouthArrears > 0)
                        {
                            previosHistory[i].FinePayment = 0;
                        }


                        Console.WriteLine("Annuity Credit Thread {0}: Payment done, Account balance - {1}, Remaining main arrears - {2}", _number, bankBook.cache, previosHistory[i].Arrears);

                        Console.WriteLine("Annuity Credit Thread {0}: End calculating payments for main arrears for the {1} month", _number, i + 1);

                        arrears = arrears - mouthArrears - surcharge;
                    }
                }
                else
                {
                    Console.WriteLine("Annuity Credit Thread {0}: Arrears on the credit does not exist", _number);
                }
                
                var curentHistory = history.Where(x => x.Month == currentMouth).FirstOrDefault();
                
                if (arrears <= 0 && ((currentMouth > credit.PayCount) || (currentMouth == credit.PayCount && curentHistory.TotalPayment - curentHistory.Paid <= 0)))
                {
                    context.Credits.FirstOrDefault(x => credit.Id == x.Id).Status = "1";
                    
                    Console.WriteLine("Annuity Credit Thread {0}: Close credit", _number);

                    context.SaveChanges();
                    context.Dispose();

                    _mut.ReleaseMutex();

                    return;
                }
                if (currentMouth <= credit.PayCount)
                {

                    if (curentHistory.TotalPayment - curentHistory.Paid <= 0)
                    {
                        Console.WriteLine("Annuity Credit Thread {0}: Payment don't need for this month", _number);

                        _mut.ReleaseMutex();

                        context.SaveChanges();
                        context.Dispose();

                        return;
                    }

                    Console.WriteLine("Annuity Credit Thread {0}: Payment need for this month", _number);

                    var pay = (int) Math.Ceiling(curentHistory.TotalPayment - curentHistory.Paid);

                    Console.WriteLine("Annuity Credit Thread {0}: Remaining payment for this month - {1}", _number, pay);

                    if (bankBook.cache < pay)
                    {
                        pay = (int) bankBook.cache;
                        Console.WriteLine("Annuity Credit Thread {0}: It can be pay only  - {1} (partial payment)",
                            _number, pay);
                    }

                    bankBook.cache -= pay;
                    curentHistory.Paid += pay;

                    Console.WriteLine(
                        "Annuity Credit Thread {0}: Payment done, Account balance - {1}, Remaining payment for mounth - {2}",
                        _number, bankBook.cache, curentHistory.TotalPayment - curentHistory.Paid < 0 ? 0 : (int)Math.Ceiling(curentHistory.TotalPayment - curentHistory.Paid);
                }
                if (arrears <= 0 && ((currentMouth > credit.PayCount) || (currentMouth == credit.PayCount && curentHistory.TotalPayment - curentHistory.Paid <= 0)))
                {
                    context.Credits.FirstOrDefault(x => credit.Id == x.Id).Status = "1";

                    Console.WriteLine("Annuity Credit Thread {0}: Close credit", _number);

                    context.SaveChanges();
                    context.Dispose();

                    _mut.ReleaseMutex();

                    return;
                }
                
                context.SaveChanges();
                context.Dispose();
            }
            _mut.ReleaseMutex();
        }
    }
}