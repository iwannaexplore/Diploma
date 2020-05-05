using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Diploma.Models;
using Diploma.Models.ViewModels;
using IronPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Diploma.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _IndexPartial(int year, int month)
        {
            MainPageViewModel model = new MainPageViewModel
            {
                EarningsChart = JsonConvert.SerializeObject(MakeEarningChart(year)),
                ExpensesChart = JsonConvert.SerializeObject(MakeExpensesChart(year)),
                RevenueChart = JsonConvert.SerializeObject(MakeRevenueChart(year)),
                EarningsAnnualCard = MakeAnnualEarningCard(year),
                ExpensesAnnualCard = MakeAnnualExpensesCard(year),
                EarningsMonthlyCard = MakeMonthlyEarningCard(year, month),
                ExpensesMonthlyCard = MakeMonthlyExpensesCard(year, month),
                PieChart = JsonConvert.SerializeObject(MakePieChart(year))
            };
            return PartialView(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult PdfResult()
        {
            return View(new PdfResultViewModel());
        }

        private string[] MakeEarningChart(int year)
        {
            string[] strArray = new string[12];

            for (int i = 1; i <= strArray.Length; i++)
            {
                var startDate = new DateTime(year, i, 1);

                var endDate = new DateTime(year, i,
                    DateTime.DaysInMonth(year, i));

                var values = _context.Contracts.Where(c => c.StartDate >= startDate && c.StartDate <= endDate).ToList();

                var result = values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * 0.07M;
                result += values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * 0.05M;
                strArray[i - 1] = string.Format("{0:0.00}", result);
            }

            return strArray;
        }

        private string[] MakeExpensesChart(int year)
        {
            var startDate = new DateTime(year, 1, 1).AddMonths(-1);
            var endDate = new DateTime(year, 12, 1);
            var promotionHistories =
                _context.PromotionHistories.Include(ph => ph.Degree).Where(ph => ph.StartDate > startDate || (ph.EndDate < endDate || ph.EndDate == null)).ToList();

            string[] strArray = new string[12];
            for (int i = 1; i <= strArray.Length; i++)
            {
                var start = new DateTime(year, i, 1);
                var end = new DateTime(year, i, DateTime.DaysInMonth(year, i));
                var values = promotionHistories.Where(e => e.StartDate <= start).ToList();
                values = values.Where(e => e.EndDate >= end || e.EndDate == null || e.EndDate?.Year < end.Year || e.EndDate?.Month == 11).ToList();
                var result = values.Select(c => c.Degree.Salary)?.Sum();
                strArray[i - 1] = string.Format("{0:0.00}", -result);
            }

            return strArray;
        }

        private string MakeAnnualEarningCard(int year)
        {
            decimal returnResult = 0;

            for (int i = 1; i <= 12; i++)
            {
                var endDate = new DateTime(year, i,
                    DateTime.DaysInMonth(year, i));
                var startDate = new DateTime(year, i, 1);
                var values = _context.Contracts.Where(c => c.StartDate <= endDate)
                    .Where(c => c.StartDate >= startDate).ToList();

                returnResult += values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * 0.07M;
                returnResult += values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * 0.05M;
            }

            return string.Format("{0:0.00}", returnResult);
        }

        private string MakeAnnualExpensesCard(int year)
        {
            var startDate = new DateTime(year, 1, 1).AddMonths(-1);
            var endDate = new DateTime(year, 12, 1);
            var promotionHistories =
                _context.PromotionHistories.Include(ph => ph.Degree).Where(ph => ph.StartDate > startDate && (ph.EndDate < endDate || ph.EndDate == null)).ToList();

            decimal? result = 0;
            for (int i = 1; i <= 12; i++)
            {
                var start = new DateTime(year, i, 1);
                var end = new DateTime(year, i, DateTime.DaysInMonth(year, i));
                var values = promotionHistories.Where(e => e.StartDate <= start).ToList();
                values = values.Where(e => e.EndDate >= end || e.EndDate == null || e.EndDate?.Year < end.Year || e.EndDate?.Month == 11).ToList();
                result += values.Select(c => c.Degree.Salary)?.Sum();
            }

            return string.Format("{0:0.00}", -result);
        }

        private string MakeMonthlyEarningCard(int year, int month)
        {
            decimal returnResult = 0;

            var endDate = new DateTime(year, month,
                DateTime.DaysInMonth(year, month));
            var startDate = new DateTime(year, month, 1);
            var values = _context.Contracts.Where(c => c.StartDate <= endDate)
                .Where(c => c.StartDate >= startDate).ToList();

            returnResult += values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * 0.07M;
            returnResult += values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * 0.05M;

            return string.Format("{0:0.00}", returnResult);
        }

        private string MakeMonthlyExpensesCard(int year, int month)
        {
            decimal? result = 0;
            var start = new DateTime(year, month, 1);
            var end = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            var values = _context.PromotionHistories.Include(c => c.Degree).Where(e => e.StartDate <= start).ToList();
            values = values.Where(e => e.EndDate >= end || e.EndDate == null || e.EndDate?.Year < end.Year || e.EndDate?.Month == 11).ToList();
            result += values?.Select(c => c.Degree.Salary)?.Sum();
            return string.Format("{0:0.00}", -result);
        }

        private string[] MakeRevenueChart(int year)
        {
            var expenses = MakeExpensesChart(year);
            var earnings = MakeEarningChart(year);
            var result = new string[12];
            var asd = int.Parse("13");
            var as1d = int.Parse("-13");
            for (int i = 0; i < 12; i++)
            {
                result[i] = string.Format("{0:0.00}", decimal.Parse(earnings[i]) + decimal.Parse(expenses[i]));
            }

            return result;
        }

        private string[] MakePieChart(int year)
        {
            string[] result = new string[2];

            var endDate = new DateTime(year, 12, 31);
            var startDate = new DateTime(year, 1, 1);
            var contractsInThisYear = _context.Contracts.Where(c => c.StartDate <= endDate)
                .Where(c => c.StartDate >= startDate).ToList();
            double allContracts = contractsInThisYear.Count;
            double purchaseNum = contractsInThisYear.Count(c => c.ContractTypeId == 1);
            double rentalNum = contractsInThisYear.Count(c => c.ContractTypeId == 2);
            result[0] = string.Format("{0:0.00}", purchaseNum / allContracts * 100);
            result[1] = string.Format("{0:0.00}", rentalNum / allContracts * 100);
            return result;
        }

        public IActionResult CreatePdfReport()
        {
            var htmlToPdf = new HtmlToPdf();

            var pdf = htmlToPdf.RenderUrlAsPdf("https://localhost:44308/Home/PdfResult");
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "MyPdf1.Pdf"));

            return RedirectToAction("PdfResult");
        }

    }
}
