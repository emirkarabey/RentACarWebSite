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
        public IActionResult Index(int id)
        {
            List<Cars> list = context.Cars.Where(x => x.MarkaId == id).ToList();
            return View("Index", list);
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
