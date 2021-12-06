using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class CarsController : Controller
    {
        private readonly RentACarContext context;
        public CarsController(RentACarContext ctx)
        {
            context = ctx;
        }
        [AllowAnonymous,HttpGet]
        public IActionResult Index(int?id,string?sirala)
        {
            if (id!=null)
            {
                if (id==2000)
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
                if (sirala!=null)
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
            context.Cars.Add(cars);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var car = context.Cars.Find(id);
            context.Cars.Remove(car);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
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
            List<Cars> list = context.Cars.ToList();
            return View(list);
        }
        [AllowAnonymous]
        public IActionResult CarsListNotSignIn()
        {
            List<Cars> list = context.Cars.ToList();
            return View(list);
        }
    }
}
