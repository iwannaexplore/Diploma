using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models.ViewModels
{
    public class SettingsViewModel
    {
        public decimal? ContributionsToFunds { get; set; }
        public decimal? IncomeTax { get; set; }
        public decimal? PaymentOfPremises { get; set; }
        public decimal? PayrollTax { get; set; }
        public decimal? PercentageOfRental { get; set; }
        public decimal? PercentageOfSales { get; set; }
    }
}
