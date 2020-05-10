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
        private readonly Reporter _reporter;
        public HomeController(ApplicationDbContext context, Reporter reporter)
        {
            _context = context;
            _reporter = reporter;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _IndexPartial(int year, int month)
        {
            MainPageViewModel model = new MainPageViewModel
            {
                IncomeChart = JsonConvert.SerializeObject(MakeIncomeChart(year)),
                ExpensesChart = JsonConvert.SerializeObject(MakeExpensesChart(year)),
                RevenueChart = JsonConvert.SerializeObject(MakeRevenueChart(year)),
                IncomeAnnualCard = MakeAnnualIncomeCard(year),
                ExpensesAnnualCard = MakeAnnualExpensesCard(year),
                IncomeMonthlyCard = MakeMonthlyIncomeCard(year, month),
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

        
        private string[] MakeIncomeChart(int year)
        {
            string[] strArray = new string[12];

            for (int month = 1; month <= strArray.Length; month++)
            {
                strArray[month - 1] = string.Format("{0:0.00}", _reporter.MonthlyIncome(year, month)); 
            }

            return strArray;
        } //ready

        private string[] MakeExpensesChart(int year)
        {
            
            string[] strArray = new string[12];
            for (int month = 1; month <= strArray.Length; month++)
            {

                var result = _reporter.MonthlyExpenses(year, month);
                strArray[month - 1] = string.Format("{0:0.00}", -result);
            }

            return strArray;
        } //ready
        private string[] MakeRevenueChart(int year)
        {
            var result = new string[12];
            for (int month = 1; month < 12; month++)
            {
                result[month-1] = string.Format("{0:0.00}", _reporter.MonthlyRevenue(year, month));
            }
            return result;
        } //ready

        private string MakeAnnualIncomeCard(int year)
        {
            return string.Format("{0:0.00}", _reporter.AnnualIncome(year));
        } //ready

        private string MakeAnnualExpensesCard(int year)
        {
            return string.Format("{0:0.00}", _reporter.AnnualExpenses(year));
        } //ready

        private string MakeMonthlyIncomeCard(int year, int month)
        {
            return string.Format("{0:0.00}", _reporter.MonthlyIncome(year, month));
        } //ready

        private string MakeMonthlyExpensesCard(int year, int month)
        {
            return string.Format("{0:0.00}", _reporter.MonthlyExpenses(year, month));
        } //ready

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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult PdfResult(int year, int month)
        {
            return View(_reporter.CreateMonthlyReport(year,month));
        }

        [HttpGet]
        public IActionResult CreateMonthlyPdfReport(int year, int month)
        {
            var htmlToPdf = new HtmlToPdf();

            var pdf = htmlToPdf.RenderUrlAsPdf($"https://localhost:44308/Home/PdfResult?year={year}&month={month}");
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "MyPdf1.Pdf"));

            return RedirectToAction("PdfResult", new {year = year, month = month});
        }

        [HttpGet]
        public IActionResult CreateAnnualPdfReport()
        {
            var htmlToPdf = new HtmlToPdf();

            var pdf = htmlToPdf.RenderUrlAsPdf("https://localhost:44308/Home/AnnualPdfResult");
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "MyPdf1.Pdf"));

            return RedirectToAction("PdfResult");
        }
    }
}
