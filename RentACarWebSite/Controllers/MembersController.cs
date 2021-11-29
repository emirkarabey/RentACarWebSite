using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly RentACarContext context;
        public MembersController(RentACarContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            List<Members> list = context.Members.ToList();
            return View(list);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Members member)
        {
            context.Members.Add(member);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var mem = context.Members.Find(id);
            context.Members.Remove(mem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var detay = context.Members.Find(id);
            return View(detay);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id,Members member)
        {
            var mem = context.Members.Find(id);
            mem.MemberName = member.MemberName;
            mem.MemberLastName = member.MemberLastName;
            mem.MemberMail = member.MemberMail;
            mem.MemberPass = member.MemberPass;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
