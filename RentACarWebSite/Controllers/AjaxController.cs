using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    [AllowAnonymous]
    public class AjaxController : Controller
    {
        private readonly RentACarContext _context;
        public AjaxController(RentACarContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string name,string cardNo)
        {
            PaymentModel person = new PaymentModel
            {
                Name = name,
                CardNo=cardNo,
                DateTime = DateTime.Now.ToString()
            };

            _context.PaymentModel.Add(person);
            _context.SaveChanges();
            return Json(person);
        }
    }
}
