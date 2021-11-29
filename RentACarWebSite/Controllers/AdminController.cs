using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly RentACarContext context;
        public AdminController(RentACarContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            List<Admin> list = context.Admin.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            context.Admin.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
