using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACarWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PaymentApiController : ControllerBase
    {
        RentACarContext _context;
        public PaymentApiController(RentACarContext context)
        {
            _context = context;
        }
        // GET: api/<PaymentApiController>
        [HttpGet]
        public List<PaymentModel> Get()
        {
            return _context.PaymentModel.ToList();
        }

        // GET api/<PaymentApiController>/5
        [HttpGet("{id}")]
        public PaymentModel Get(int id)
        {
            var y = _context.PaymentModel.FirstOrDefault(x => x.PaymentId == id);
            return y;
        }

        // POST api/<PaymentApiController>
        [HttpPost]
        public void Post([FromBody] PaymentModel payment)
        {
            _context.PaymentModel.Add(payment);
            _context.SaveChanges();
        }

        // PUT api/<PaymentApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PaymentModel payment)
        {
            var y = _context.PaymentModel.FirstOrDefault(x => x.PaymentId == id);
            if (y is null)
            {
                return NotFound();
            }
            else
            {
                y.CardNo = payment.CardNo;
                y.DateTime = payment.DateTime;
                y.Name = payment.Name;
                _context.Update(y);
                _context.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<PaymentApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var y1 = _context.PaymentModel.FirstOrDefault(x => x.PaymentId == id);
            if (y1 is null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(y1);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
