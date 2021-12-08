using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class CarsController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;

        private readonly RentACarContext context;
        public CarsController(RentACarContext ctx, IHtmlLocalizer<HomeController> localizer)
        {
            context = ctx;
            _localizer = localizer;
        }

        [HttpPost,AllowAnonymous]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            var memberMail = User.Identity.Name;
            var memberRol = context.Members.Where(x => x.MemberMail == memberMail).Select(x => x.Rol).FirstOrDefault();
            if (memberRol.Equals("B"))
            {
                TempData["value"] = memberRol;
            }
            else
            {
                TempData["value"] = "A";
            }
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        [AllowAnonymous,HttpGet]
        public IActionResult Index(int?id,string?sirala)
        {
            if (id != null)
            {
                if (id == 2000)
                {
                    if (sirala != null)
                    {
                        if (sirala.Equals("Artan"))
                        {
                            List<Cars> list = context.Cars.OrderBy(x => x.Price).ToList();
                            return View("Index", list);
                        }
                        else if (sirala.Equals("Azalan"))
                        {
                            List<Cars> list = context.Cars.OrderByDescending(x => x.Price).ToList();
                            return View("Index", list);
                        }

                    }
                    else
                    {
                        List<Cars> list = context.Cars.ToList();
                        return View("Index", list);
                    }
                }
                if (sirala != null)
                {
                    if (sirala.Equals("Artan"))
                    {
                        List<Cars> list = context.Cars.Where(x => x.MarkaId == id).OrderBy(x => x.Price).ToList();
                        return View("Index", list);
                    }
                    else if (sirala.Equals("Azalan"))
                    {
                        List<Cars> list = context.Cars.Where(x => x.MarkaId == id).OrderByDescending(x => x.Price).ToList();
                        return View("Index", list);
                    }

                }
                else
                {
                    List<Cars> list = context.Cars.Where(x => x.MarkaId == id).ToList();
                    return View("Index", list);
                }
            }
            else
            {
                if (sirala.Equals("Artan"))
                {
                    List<Cars> list = context.Cars.OrderBy(x => x.Price).ToList();
                    return View("Index", list);
                }
                else if (sirala.Equals("Azalan"))
                {
                    List<Cars> list = context.Cars.OrderByDescending(x => x.Price).ToList();
                    return View("Index", list);
                }
            }
            return View();
        }

        [AllowAnonymous,HttpPost]
        public IActionResult Index()
        {
            List<Cars> list = context.Cars.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cars cars)
        {
            TempData["value"] = "A";
            context.Cars.Add(cars);
            context.SaveChanges();
            return RedirectToAction("CarsList");
        }

        public IActionResult Delete(int id)
        {
            TempData["value"] = "A";
            var car = context.Cars.Find(id);
            context.Cars.Remove(car);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            TempData["value"] = "A";
            var detay = context.Cars.Find(id);
            return View(detay);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, Cars car)
        {
            TempData["value"] = "A";
            var cr = context.Cars.Find(id);
            cr.CarFoto = car.CarFoto;
            cr.CarModel = car.CarModel;
            cr.CarYear = car.CarYear;
            
            cr.CarColor = car.CarColor;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult CarsList()
        {
            var memberMail = User.Identity.Name;
            var memberRol = context.Members.Where(x => x.MemberMail == memberMail).Select(x=>x.Rol).FirstOrDefault();
            if (memberRol=="B")
            {
                TempData["value"] = "B";
            }
            else
            {
                TempData["value"] = "A";
            }
            
            List<Cars> list = context.Cars.ToList();
            return View(list);
        }
        [AllowAnonymous]
        public IActionResult CarsListNotSignIn()
        {
            List<Cars> list = context.Cars.ToList();
            return View(list);
        }

        public IActionResult Cars()
        {

            List<Cars> list = context.Cars.ToList();
            return View(list);
        }
    }
}
