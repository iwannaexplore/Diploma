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
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Diploma.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            MainPageViewModel model = new MainPageViewModel
            {
                Earnings = JsonConvert.SerializeObject(MakeEarningChart()),
                Expenses = JsonConvert.SerializeObject(MakeExpensesChart()),
                EarningsAnnualCard = MakeAnnualEarningCard(),
                ExpensesAnnualCard = MakeAnnualExpensesCard(),
                EarningsMonthlyCard = MakeMonthlyEarningCard(),
                ExpensesMonthlyCard = MakeMonthlyExpensesCard()
            };
            return View(model);
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

        public IActionResult PdfResult()
        {
            return View(_context.Buyers.FirstOrDefault());
        }

        private string[] MakeEarningChart()
        {
            string[] strArray = new string[12];

            for (int i = 1; i <= strArray.Length; i++)
            {
                var endDate = new DateTime(DateTime.Now.Year, i,
                    DateTime.DaysInMonth(DateTime.Now.Year, i));
                var startDate = new DateTime(DateTime.Now.Year, i, 1);
                var values = _context.Contracts.Where(c => c.StartDate > startDate && c.StartDate < endDate).ToList();

                var result = values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * 0.07M;
                result += values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * 0.05M;
                strArray[i - 1] = string.Format("{0:0.00}", result);
            }

            return strArray;
        }
        private string[] MakeExpensesChart()
        {
            var endDate = new DateTime(DateTime.Now.Year, 12,
                DateTime.DaysInMonth(DateTime.Now.Year, 12));
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var employee = _context.Employees.Where(e => e.StartDateOfWork < endDate)
                .Where(e => e.EndDateOfWork > startDate).ToList();

            string[] strArray = new string[12];
            for (int i = 1; i <= strArray.Length; i++)
            {
                var end = new DateTime(DateTime.Now.Year, i,
                    DateTime.DaysInMonth(DateTime.Now.Year, i));
                var start = new DateTime(DateTime.Now.Year, i, 1);
                var values = employee.Where(e => e.StartDateOfWork <= start).Where(e => e.EndDateOfWork >= end).ToList();
                var result = values.Select(c => c.Salary).Sum();
                strArray[i - 1] = string.Format("{0:0.00}", -result);
            }

            return strArray;
        } //доделать

        private string MakeAnnualEarningCard()
        {
            decimal returnResult = 0;

            for (int i = 1; i <= 12; i++)
            {
                var endDate = new DateTime(DateTime.Now.Year, i,
                    DateTime.DaysInMonth(DateTime.Now.Year, i));
                var startDate = new DateTime(DateTime.Now.Year, i, 1);
                var values = _context.Contracts.Where(c => c.StartDate <= endDate)
                    .Where(c => c.StartDate >= startDate).ToList();

                returnResult += values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * 0.07M;
                returnResult += values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * 0.05M;
            }

            return string.Format("{0:0.00}", returnResult);
        }

        private string MakeAnnualExpensesCard()
        {
            var endDate = new DateTime(DateTime.Now.Year, 12,
                DateTime.DaysInMonth(DateTime.Now.Year, 12));
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var employee = _context.Employees.Where(e => e.StartDateOfWork < endDate)
                .Where(e => e.EndDateOfWork > startDate).ToList();

            decimal strArray = 0;
            for (int i = 1; i <= 12; i++)
            {
                var end = new DateTime(DateTime.Now.Year, i,
                    DateTime.DaysInMonth(DateTime.Now.Year, i));
                var start = new DateTime(DateTime.Now.Year, i, 1);
                var values = employee.Where(e => e.StartDateOfWork < start).Where(e => e.EndDateOfWork > end).ToList();
                var result = values.Select(c => c.Salary).Sum();
                strArray += result;
            }

            return string.Format("{0:0.00}", strArray);
        } // доделать

        private string MakeMonthlyEarningCard()
        {
            decimal returnResult = 0;

            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var values = _context.Contracts.Where(c => c.StartDate <= endDate)
                .Where(c => c.StartDate >= startDate).ToList();

            returnResult += values.Where(c => c.ContractTypeId == 1).Select(c => c.Price).Sum() * 0.07M;
            returnResult += values.Where(c => c.ContractTypeId == 2).Select(c => c.Price).Sum() * 0.05M;

            return string.Format("{0:0.00}", returnResult);
        }

        private string MakeMonthlyExpensesCard()
        {
            var endDate = new DateTime(DateTime.Now.Year, 12,
                DateTime.DaysInMonth(DateTime.Now.Year, 12));
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var employee = _context.Employees.Where(e => e.StartDateOfWork < endDate)
                .Where(e => e.EndDateOfWork > startDate).ToList();
            decimal strArray = 0;
            var end = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            var start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var values = employee.Where(e => e.StartDateOfWork < start).Where(e => e.EndDateOfWork > end).ToList();
            var result = values.Select(c => c.Salary).Sum();
            strArray += result;


            return string.Format("{0:0.00}", strArray);
        } //доделать

        public IActionResult CreatePdfReport()
        {
            var html = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestPdf.html"));

            var htmlToPdf = new HtmlToPdf();
            
            var pdf = htmlToPdf.RenderUrlAsPdf("https://localhost:44308/Home/PdfResult");
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "MyPdf.Pdf"));

            return RedirectToAction("Index");
        }
    }
}
