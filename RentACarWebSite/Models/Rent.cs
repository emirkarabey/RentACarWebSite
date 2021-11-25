using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class Rent
    {
        [Key]
        public int RentID { get; set; }
        public DateTime RentDate { get; set; }
        public int MemberID { get; set; }
        public int CarID { get; set; }
        public int AdminID { get; set; }

        public Admin Admin { get; set; }
        public Cars Car { get; set; }
        public Members Member { get; set; }
    }
}
