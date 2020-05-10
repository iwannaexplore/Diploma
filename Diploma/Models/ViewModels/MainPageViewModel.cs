using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Diploma.Models.ViewModels
{
    public class MainPageViewModel
    {
        public string ExpensesChart { get; set; }
        public string IncomeChart { get; set; }
        public string RevenueChart { get; set; }
        public string IncomeMonthlyCard { get; set; }
        public string IncomeAnnualCard { get; set; }
        public string ExpensesMonthlyCard { get; set; }
        public string ExpensesAnnualCard { get; set; }
        public string PieChart { get; set; }
        
    }
}
