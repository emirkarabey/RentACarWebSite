using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class Cars
    {
        [Key]
        public int CarID { get; set; }
        public string CarFoto { get; set; }
        public int CarYear { get; set; }
        public int Price { get; set; }
        public string CarModel { get; set; }
        public string CarMarka { get; set; }
        public string CarColor { get; set; }
        public Admin Admin { get; set; }
    }
}
