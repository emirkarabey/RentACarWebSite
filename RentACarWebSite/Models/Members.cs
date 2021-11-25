using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class Members
    {
        [Key]
        public int MemberID { get; set; }
        public string MemberPass { get; set; }
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberMail { get; set; }
    }
}
