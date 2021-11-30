﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    public class AccountController : Controller
    {

        private readonly RentACarContext context;

        public AccountController( RentACarContext ctx)
        {
            
            context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUpMembers()
        {

            return View();
        }
        [HttpGet, AllowAnonymous]
        public IActionResult SignInMembers()
        {
            return View();
        }
        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> SignInMembers(Members member)
        {
            var datavalue = context.Members.FirstOrDefault(x => x.MemberMail == member.MemberMail && x.MemberPass == member.MemberPass);
            if (datavalue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,member.MemberMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("CarsList", "Cars");
            }
            else
            {
                return View();
            }

        }
        public async Task<IActionResult> Register(Members member)
        {
            await context.AddAsync(member);
            await context.SaveChangesAsync();
            return Redirect("/Home/Index");
        }
    }
}