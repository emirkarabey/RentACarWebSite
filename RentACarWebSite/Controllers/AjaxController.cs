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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string name,string cardNo)
        {
            PersonModel person = new PersonModel
            {
                Name = name,
                CardNo=cardNo,
                DateTime = DateTime.Now.ToString()
            };

            return Json(person);
        }
    }
}
