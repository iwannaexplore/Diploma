using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models.ViewModels
{
    public class PdfResultViewModel
    {
        public string Name;

        public string Created;
        public string Due;

        public string Income;
        public string Expenses;
        public string GrossProfitOrLoss;
        public string Taxes;
        public string NetProfit;

        public string PayrollTax;
        public string ContributionsToFunds;
        public string IncomeTax;
        public string TotalForTaxes;

        public string Salary;
        public string PaymentOfPremises;
        public string TotalForExpenses;

        public string RentalService;
        public string PurchaseService;
        public string TotalForIncomes;
    }
}
