using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApp.Models.Domains.Credits
{
    public class CreditHistoryViewModel
    {
        public CreditHistoryViewModel()
        {
            CurrentPageNumber = 1;
            CreditHistories = new List<CreditHistoryItemViewModel>();
        }

        public IEnumerable<CreditHistoryItemViewModel> CreditHistories { get; set; }

        public Guid CreditId { get; set; }

        public int CurrentPageNumber { get; set; }

        public int AllPageCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool IsSearch { get; set; }
    }
}