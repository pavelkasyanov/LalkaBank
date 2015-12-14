using System;
using System.Collections.Generic;
using System.Linq;
using DAO;

namespace Cron
{
    public static class AnnuityCreadit
    {
        private static readonly LalkaBankDabaseModelContainer _db = new LalkaBankDabaseModelContainer();

        public static void ProcessHistory(Guid creditId)
        {
            var credit = _db.Credits.Find(creditId);

            if (credit == null)
            {
                return;
            }

            if (_db.CreditHistory.Any( history => history.CreditId == credit.Id))
            {
                return;
            }

            List<History> list = AnnuityCreadit.CalculateHistory(credit.AllSum, credit.Percent / 100, credit.PayCount);
            List<CreditHistory> result = new List<CreditHistory>();

            foreach (var item in list)
            {
                var historyItem = new CreditHistory
                {
                    Id = Guid.NewGuid(),
                    Month = item.Month,
                    CreditBalance = (decimal)item.Residue,
                    MainPayment = (decimal)item.Debt,
                    Percent = (decimal)item.Percent,
                    TotalPayment = (decimal)AnnuityCreadit.CalculateMonthlyPayment(credit.StartSum, credit.Percent / 100, credit.PayCount),
                    Paid = 0,
                    Arrears = 0,
                    Fine = 0,
                    CreditId = credit.Id
                };

                result.Add(historyItem);
            }

            _db.CreditHistory.AddRange(result);

            _db.SaveChanges();
        }

        private class History
        {
            public int Month;
            public double Percent;
            public double Debt;
            public double Residue;
        }

        private static double CalculateMonthlyPayment(double total, double rate, int month)
        {
            double percent = rate / 12;
            double payment = total * (percent + percent / (Math.Pow(1 + percent, month) - 1));
            
            return payment;
        }

        private static List<History> CalculateHistory(double total, double rate, int month)
        {
            double payment = AnnuityCreadit.CalculateMonthlyPayment(total, rate, month);

            List<History> historyList = new List<History>();

            double residue = total;

            for (int i = 1; i <= month; i++)
            {
                double percent = residue * rate / 12;
                double debt = payment - percent;

                History history = new History()
                {
                    Month = i,
                    Percent = percent,
                    Debt = debt,
                    Residue = residue
                };

                historyList.Add(history);

                residue -= debt;

            }

            return historyList;
        }

    }
}
