using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class RentController : Controller
    {
        private readonly RentACarContext context;
        public RentController(RentACarContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            List<Rent> list = context.Rent.ToList();
            return View(list);
        }
    }
}
