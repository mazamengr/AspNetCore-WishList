using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.Items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            Item itemToRemove = _context.Items.Find(Id);
            if (itemToRemove != null)
            {
                _context.Items.Remove(itemToRemove);
            }
            _context.SaveChanges();

            RedirectToAction("Index");
        }
    }
}
