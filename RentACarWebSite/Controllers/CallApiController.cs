using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentACarWebSite.Controllers
{
    [AllowAnonymous]
    public class CallApiController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            List<PaymentModel> payments = new List<PaymentModel>();
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44366/api/PaymentApi");
            string apiResponse = await response.Content.ReadAsStringAsync();
            
            payments = JsonConvert.DeserializeObject<List<PaymentModel>>(apiResponse);
            return View(payments);
        }
    }
}
