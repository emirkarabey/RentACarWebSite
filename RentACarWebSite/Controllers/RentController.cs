using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            List<Rent> list = context.Rent.Include(x=>x.Admin).Include(x=>x.Car).Include(x=>x.Member).ToList();
            return View(list);
        }

        public IActionResult RentCar(int id)
        {

            var memberMail = User.Identity.Name;
            var member = context.Members.Where(x => x.MemberMail == memberMail).FirstOrDefault();
            var adminId = 4;

            

            Rent rent = new Rent();
            rent.RentDate = System.DateTime.Now;
            rent.MemberID = member.MemberID;
            rent.CarID = id;
            rent.AdminID = adminId;
            TempData["name"] = member.MemberID;
            TempData["value"] = "Member";
            context.Rent.Add(rent);
            context.SaveChanges();
            var car = context.Cars.Find(id);
            TempData["price"] = car.Price.ToString();
            context.Cars.Remove(car);
            context.SaveChanges();
            return RedirectToAction("Index", "Ajax");
        }

        
    }
}
