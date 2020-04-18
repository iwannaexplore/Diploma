using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Data;
using Diploma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    public class CrudController : Controller
    {
        private ApplicationDbContext _context;

        public CrudController (ApplicationDbContext context)
        {
            _context = context;
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
            return RedirectToAction("ShowBuyers");
        }
        public IActionResult ShowBuyers()
        {
            return View(_context.Buyers.ToList());
        }
        [HttpGet]
        public IActionResult EditBuyer(int id)
        {
            return View(_context.Buyers.FirstOrDefault(b=>b.Id == id));
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
    }
}