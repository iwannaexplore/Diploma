using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Data;
using Diploma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Controllers
{
    [Authorize]
    public class CrudController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<Employee> _userManager;

        public CrudController(ApplicationDbContext context, UserManager<Employee> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddBuyer()
        {
            return View(new Buyer());
        }

        [HttpPost]
        public IActionResult AddBuyer(Buyer buyer)
        {

            _context.Buyers.Add(buyer);
            _context.SaveChanges();
            return RedirectToAction("AddBuyer");

        }

        public IActionResult ShowBuyers()
        {
            return View(_context.Buyers.ToList());
        }

        [HttpGet]
        public IActionResult EditBuyer(int id)
        {
            return View(_context.Buyers.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        public IActionResult EditBuyer(Buyer buyer)
        {
            _context.Buyers.Update(buyer);
            _context.SaveChanges();
            return RedirectToAction("ShowBuyers");
        }

        public IActionResult DeleteBuyer(int id)
        {
            List<Contract> newContract = _context.Contracts.Where(c => c.BuyerId == id).ToList();
            foreach (var contract in newContract)
            {
                contract.BuyerId = null;
            }
            _context.Contracts.UpdateRange(newContract);
            _context.SaveChanges();
            _context.Buyers.RemoveRange(_context.Buyers.FirstOrDefault(b => b.Id == id));
            _context.SaveChanges();
            return RedirectToAction("ShowBuyers");
        }

        [HttpGet]
        public IActionResult AddContract()
        {
            ViewBag.ContractTypeId = new SelectList(_context.ContractTypes, "Id", "Type");
            ViewBag.SellerId = _context.Sellers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            ViewBag.BuyerId = _context.Buyers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            ViewBag.HouseId = new SelectList(_context.Houses, "Id", "Address");
            ViewBag.EmployeeId = _context.Employees.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            var contract = new Contract();
            contract.StartDate = DateTime.Now;
            return View(contract);
        }

        [HttpPost]
        public IActionResult AddContract(Contract contract)
        {
            _context.Add(contract);
            _context.SaveChanges();
            return RedirectToAction("AddContract");
        }

        public IActionResult ShowContracts()
        {
            List<Contract> contracts = _context.Contracts.Include(c => c.Seller)
                .Include(c => c.Buyer).Include(c => c.Employee)
                .Include(c => c.House).Include(c => c.ContractType).ToList();
            return View(contracts);
        }

        [HttpGet]
        public IActionResult EditContract(int id)
        {
            ViewBag.ContractTypeId = new SelectList(_context.ContractTypes, "Id", "Type");
            ViewBag.SellerId = _context.Sellers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();

            ViewBag.BuyerId = _context.Buyers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            ViewBag.HouseId = new SelectList(_context.Houses, "Id", "Address");
            ViewBag.EmployeeId = _context.Employees.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            return View(_context.Contracts.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult EditContract(Contract contract)
        {
            _context.Update(contract);
            _context.SaveChanges();
            return RedirectToAction("ShowContracts");
        }

        public IActionResult DeleteContract(int id)
        {
            _context.RemoveRange(_context.Contracts.Where(c => c.Id == id));
            _context.SaveChanges();
            return RedirectToAction("ShowContracts");
        }

        [HttpGet]
        public IActionResult AddHouse()
        {
            ViewBag.SellerId = _context.Sellers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            return View(new House());
        }

        [HttpPost]
        public IActionResult AddHouse(House house)
        {
            _context.Houses.Add(house);
            _context.SaveChanges();
            return RedirectToAction("AddHouse");
        }

        public IActionResult ShowHouses()
        {
            return View(_context.Houses.Include(h => h.Seller).ToList());
        }

        [HttpGet]
        public IActionResult EditHouse(int id)
        {
            ViewBag.SellerId = _context.Sellers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Surname
            }).ToList();
            return View(_context.Houses.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        public IActionResult EditHouse(House house)
        {
            _context.Houses.Update(house);
            _context.SaveChanges();
            return RedirectToAction("ShowHouses");
        }

        public IActionResult DeleteHouse(int id)
        {
            List<Contract> dependingContracts = _context.Contracts.Where(c => c.HouseId == id).ToList();
            _context.Contracts.RemoveRange(dependingContracts);
            _context.SaveChanges();
            _context.Houses.RemoveRange(_context.Houses.FirstOrDefault(b => b.Id == id));
            _context.SaveChanges();
            return RedirectToAction("ShowHouses");
        }

        [HttpGet]
        public IActionResult AddSeller()
        {
            return View(new Seller());
        }

        [HttpPost]
        public IActionResult AddSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();
            return RedirectToAction("AddSeller");
        }

        public IActionResult ShowSellers()
        {
            return View(_context.Sellers.ToList());
        }

        [HttpGet]
        public IActionResult EditSeller(int id)
        {
            return View(_context.Sellers.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        public IActionResult EditSeller(Seller seller)
        {
            _context.Sellers.Update(seller);
            _context.SaveChanges();
            return RedirectToAction("ShowSellers");
        }

        public IActionResult DeleteSeller(int id)
        {
            List<Contract> newContract = _context.Contracts.Where(c => c.SellerId == id).ToList();
            _context.Contracts.RemoveRange(newContract);
            _context.SaveChanges();
            _context.Sellers.RemoveRange(_context.Sellers.FirstOrDefault(b => b.Id == id));
            _context.SaveChanges();
            return RedirectToAction("ShowSellers");
        }

        public IActionResult ShowEmployees()
        {
            return View(_context.Employees.Include(e => e.PromotionHistories).ThenInclude(ph => ph.Degree).ToList());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            int defaultValue = _context.PromotionHistories.FirstOrDefault(ph => ph.EmployeeId == id && ph.EndDate == null).DegreeId;
            ViewBag.DegreeId = new SelectList(_context.Degrees.ToList(), "Id", "Name", defaultValue);
            return View(_context.Employees.FirstOrDefault(e => e.Id == id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditEmployee(Employee employee, int degreeId)
        {
            var oldHistory = _context.PromotionHistories.FirstOrDefault(ph => ph.EmployeeId == employee.Id && ph.EndDate == null);
            oldHistory.EndDate = DateTime.Now;
            if (oldHistory.DegreeId == degreeId)
            {
                return RedirectToAction("ShowEmployees");
            }
            _context.PromotionHistories.Update(oldHistory);
            _context.SaveChanges();
            PromotionHistory newHistory = new PromotionHistory { DegreeId = degreeId, EmployeeId = employee.Id, StartDate = DateTime.Now, EndDate = null };
            _context.PromotionHistories.Add(newHistory);
            _context.SaveChanges();
            var newEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            newEmployee.Name = employee.Name;
            newEmployee.Surname = employee.Surname;
            newEmployee.UserName = employee.Email;
            newEmployee.NormalizedUserName = employee.Email.ToUpperInvariant();
            newEmployee.Email = employee.Email;
            newEmployee.NormalizedEmail = employee.Email.ToUpperInvariant();
            _context.Employees.Update(newEmployee);
            _context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewBag.DegreeId = new SelectList(_context.Degrees.ToList(), "Id", "Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee, int degreeId)
        {
            await InitializeAsync(employee);
            await Task.Run(() => AddPromotionToUser(employee.Email, degreeId));
            return RedirectToAction("AddEmployee");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmployee(int id)
        {
            var oldHistory = _context.PromotionHistories.FirstOrDefault(ph => ph.EmployeeId == id && ph.EndDate == null);
            oldHistory.EndDate = DateTime.Now;
            _context.PromotionHistories.Update(oldHistory);
            _context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ReturnEmployee(int id)
        {
            var oldHistory = _context.PromotionHistories.OrderBy(ph => ph.EndDate).LastOrDefault(ph => ph.EmployeeId == id);
            PromotionHistory newHistory = new PromotionHistory { DegreeId = oldHistory.DegreeId, EmployeeId = oldHistory.EmployeeId, StartDate = DateTime.Now, EndDate = null };
            _context.PromotionHistories.Add(newHistory);
            _context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }

        public JsonResult GetHousesBySellerId(int id)
        {
            List<House> list = _context.Houses.Where(h => h.SellerId == id).ToList();

            return Json(new SelectList(list, "Id", "Address"));
        }

        private async Task InitializeAsync(Employee employee)
        {
            string email = employee.Email;
            string name = employee.Name;
            string surname = employee.Surname;
            string password = employee.PasswordHash;

            if (await _userManager.FindByEmailAsync(email) == null)
            {
                Employee newEmployee = new Employee { Email = email, UserName = email, EmailConfirmed = true, Name = name, Surname = surname };
                IdentityResult result = await _userManager.CreateAsync(newEmployee, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newEmployee, "User");
                }
            }
        }

        private void AddPromotionToUser(string email, int degreeId)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Email == email);
            _context.PromotionHistories.Add(
                new PromotionHistory
                {
                    DegreeId = degreeId,
                    EmployeeId = employee.Id,
                    StartDate = DateTime.Now,
                    EndDate = null
                });
            _context.SaveChanges();
        }

    }

}