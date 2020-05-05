using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models.ViewModels
{
    public class PdfResultViewModel
    {
        public string Created;
        public string Due;

        public double Income;
        public double Expenses;
        public double GrossProfitOrLoss;
        public double Taxes;
        public double NetProfit;
        public double TotalForMain;

        public double PayrollTax;
        public double ContributionsToFunds;
        public double IncomeTax;
        public double TotalForTaxes;

        public double Salary;
        public double PaymentOfPremises;
        public double TotalForExpenses;

        public double RentalService;
        public double PurchaseService;
        public double TotalForIncomes;
    }
}
