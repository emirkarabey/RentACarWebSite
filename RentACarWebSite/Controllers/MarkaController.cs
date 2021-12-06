using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class MarkaController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
