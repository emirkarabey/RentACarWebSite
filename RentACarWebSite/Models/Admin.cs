using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminPass { get; set; }
        public string AdminMail { get; set; }
        public int MyProperty { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
