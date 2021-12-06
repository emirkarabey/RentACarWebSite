using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public string MarkaName { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
