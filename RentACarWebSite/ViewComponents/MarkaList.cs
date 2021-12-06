using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.ViewComponents
{
    public class MarkaList : ViewComponent
    {
        private readonly RentACarContext context;
        public MarkaList(RentACarContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            List<Marka> list = context.Marka.ToList();
            return View(list);
        }
    }
}
