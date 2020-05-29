using System;
using System.Linq;
using Diploma.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Data
{
    public class Reporter
    {
        private readonly ApplicationDbContext _context;

        private readonly decimal? _contributionsToFunds =
            decimal.Parse(Environment.GetEnvironmentVariable("ContributionsToFunds"));

        private readonly decimal? _incomeTax = decimal.Parse(Environment.GetEnvironmentVariable("IncomeTax"));

        private readonly decimal? _paymentOfPremises =
            decimal.Parse(Environment.GetEnvironmentVariable("PaymentOfPremises"));

        private readonly decimal? _payrollTax = decimal.Parse(Environment.GetEnvironmentVariable("PayrollTax"));

        private readonly decimal? _percentageOfRental =
            decimal.Parse(Environment.GetEnvironmentVariable("PercentageOfRental"));

        private readonly decimal? _percentageOfSales =
            decimal.Parse(Environment.GetEnvironmentVariable("PercentageOfSales"));

        public Reporter(ApplicationDbContext context)
        {
            _context = context;
        }

        public PdfResultViewModel CreateMonthlyReport(int year, int month)
        {
            PdfResultViewModel model = new PdfResultViewModel
            {
                Created = DateOfCreation(year, month).ToString("d"),
                Due = EndDate(year, month).ToString("d"),

                Income = string.Format("{0:0.00}", MonthlyTotalForIncomes(year, month)),
                Expenses = string.Format("{0:0.00}", MonthlyTotalForExpenses(year, month)),
                GrossProfitOrLoss = string.Format("{0:0.00}", MonthlyRevenue(year, month)),
                Taxes = string.Format("{0:0.00}", MonthlyTotalForTaxes(year, month)),
                NetProfit = string.Format("{0:0.00}", MonthlyNetProfit(year, month)),
                PayrollTax = string.Format("{0:0.00}", MonthlyPayrollTax(year, month)),
                ContributionsToFunds = string.Format("{0:0.00}", MonthlyContributionsToFunds(year, month)),
                IncomeTax = string.Format("{0:0.00}", MonthlyIncomeTax(year, month)),
                TotalForTaxes = string.Format("{0:0.00}", MonthlyTotalForTaxes(year, month)),
                Salary = string.Format("{0:0.00}", MonthlySalary(year, month)),
                PaymentOfPremises = string.Format("{0:0.00}", MonthlyPaymentOfPremises(year, month)),
                TotalForExpenses = string.Format("{0:0.00}", MonthlyTotalForExpenses(year, month)),
                RentalService = string.Format("{0:0.00}", MonthlyRentalService(year, month)),
                PurchaseService = string.Format("{0:0.00}", MonthlyPurchaseService(year, month)),
                TotalForIncomes = string.Format("{0:0.00}", MonthlyTotalForIncomes(year, month))
            };


            return model;
        }

        public PdfResultViewModel CreateAnnualReport(int year)
        {
            PdfResultViewModel model = new PdfResultViewModel
            {
                Created = DateOfCreation(year, 1).ToString("d"),
                Due = EndDate(year, 12).ToString("d"),

                Income = string.Format("{0:0.00}", AnnualFunction(year, MonthlyTotalForIncomes)),
                Expenses = string.Format("{0:0.00}", AnnualFunction(year, MonthlyTotalForExpenses)),
                GrossProfitOrLoss = string.Format("{0:0.00}", AnnualFunction(year, MonthlyRevenue)),
                Taxes = string.Format("{0:0.00}", AnnualFunction(year, MonthlyTotalForTaxes)),
                NetProfit = string.Format("{0:0.00}", AnnualFunction(year, MonthlyNetProfit)),
                PayrollTax = string.Format("{0:0.00}", AnnualFunction(year, MonthlyPayrollTax)),
                ContributionsToFunds = string.Format("{0:0.00}", AnnualFunction(year, MonthlyContributionsToFunds)),
                IncomeTax = string.Format("{0:0.00}", AnnualFunction(year, MonthlyIncomeTax)),
                TotalForTaxes = string.Format("{0:0.00}", AnnualFunction(year, MonthlyTotalForTaxes)),
                Salary = string.Format("{0:0.00}", AnnualFunction(year, MonthlySalary)),
                PaymentOfPremises = string.Format("{0:0.00}", AnnualFunction(year, MonthlyPaymentOfPremises)),
                TotalForExpenses = string.Format("{0:0.00}", AnnualFunction(year, MonthlyTotalForExpenses)),
                RentalService = string.Format("{0:0.00}", AnnualFunction(year, MonthlyRentalService)),
                PurchaseService = string.Format("{0:0.00}", AnnualFunction(year, MonthlyPurchaseService)),
                TotalForIncomes = string.Format("{0:0.00}", AnnualFunction(year, MonthlyTotalForIncomes))
            };


            return model;
        }

        private DateTime DateOfCreation(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        private DateTime EndDate(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }

        private decimal? MonthlyNetProfit(int year, int month)
        {
            return MonthlyRevenue(year, month) - MonthlyTotalForTaxes(year, month);
        }

        private decimal? MonthlyPayrollTax(int year, int month)
        {
            return MonthlyExpenses(year, month) * _payrollTax;
        }

        private decimal? MonthlyContributionsToFunds(int year, int month)
        {
            return MonthlyExpenses(year, month) * _contributionsToFunds;
        }

        private decimal? MonthlyIncomeTax(int year, int month)
        {
            return MonthlyRevenue(year, month) * _incomeTax;
        }

        private decimal? MonthlyTotalForTaxes(int year, int month)
        {
            return MonthlyPayrollTax(year, month) + MonthlyContributionsToFunds(year, month) +
                   MonthlyIncomeTax(year, month);
        }

        private decimal? MonthlySalary(int year, int month)
        {
            return MonthlyExpenses(year, month);
        }

        private decimal? MonthlyPaymentOfPremises(int year, int month)
        {
            return _paymentOfPremises;
        }

        private decimal? MonthlyTotalForExpenses(int year, int month)
        {
            return MonthlySalary(year, month) + MonthlyPaymentOfPremises(year, month);
        }

        private decimal? MonthlyRentalService(int year, int month)
        {
            var startDate = new DateTime(year, month, 1);

            var endDate = new DateTime(year, month,
                DateTime.DaysInMonth(year, month));

            var values = _context.Contracts.Where(c => c.StartDate >= startDate && c.StartDate <= endDate).ToList();
            var result = values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * _percentageOfRental;

            return result;
        }

        private decimal? MonthlyPurchaseService(int year, int month)
        {
            var startDate = new DateTime(year, month, 1);

            var endDate = new DateTime(year, month,
                DateTime.DaysInMonth(year, month));

            var values = _context.Contracts.Where(c => c.StartDate >= startDate && c.StartDate <= endDate).ToList();
            return values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * _percentageOfSales;
        }

        private decimal? MonthlyTotalForIncomes(int year, int month)
        {
            return MonthlyRentalService(year, month) + MonthlyPurchaseService(year, month);
        }


        public decimal? MonthlyIncome(int year, int month)
        {
            var startDate = new DateTime(year, month, 1);

            var endDate = new DateTime(year, month,
                DateTime.DaysInMonth(year, month));

            var values = _context.Contracts.Where(c => c.StartDate >= startDate && c.StartDate <= endDate).ToList();
            var result = values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * _percentageOfRental
                         + values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * _percentageOfSales;

            return result;
        }

        public decimal? MonthlyExpenses(int year, int month)
        {
            var startDate = new DateTime(year, 1, 1).AddMonths(-1);
            var endDate = new DateTime(year, 12, 1);
            var promotionHistories =
                _context.PromotionHistories.Include(ph => ph.Degree).Where(ph =>
                    ph.StartDate > startDate || ph.EndDate < endDate || ph.EndDate == null).ToList();

            var start = new DateTime(year, month, 1);
            var end = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            var values = promotionHistories.Where(e => e.StartDate <= start).ToList();
            values = values.Where(e =>
                e.EndDate >= end || e.EndDate == null || e.EndDate?.Year < end.Year || e.EndDate?.Month == 11).ToList();
            return values.Select(c => c.Degree.Salary)?.Sum();
        }

        public decimal? MonthlyRevenue(int year, int month)
        {
            return MonthlyIncome(year, month) - MonthlyExpenses(year, month);
        }

        public decimal? AnnualFunction(int year, Func<int, int, decimal?> monthlyFunction)
        {
            decimal? result = 0;

            for (var month = 1; month <= 12; month++) result += monthlyFunction(year, month);

            return result;
        }

    }
}