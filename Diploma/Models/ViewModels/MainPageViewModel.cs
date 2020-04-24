using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Diploma.Models.ViewModels
{
    public class MainPageViewModel
    {
        public string Expenses { get; set; }
        public string Earnings { get; set; }
        public string EarningsMonthlyCard { get; set; }
        public string EarningsAnnualCard { get; set; }
        public string ExpensesMonthlyCard { get; set; }
        public string ExpensesAnnualCard { get; set; }
    }
}
