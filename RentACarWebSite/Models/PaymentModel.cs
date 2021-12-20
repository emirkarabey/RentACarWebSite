using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public string DateTime { get; set; }
        public string CardNo { get; set; }
    }
}
