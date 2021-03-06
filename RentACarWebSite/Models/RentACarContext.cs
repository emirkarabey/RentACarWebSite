using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWebSite.Models
{
    public class RentACarContext : DbContext
    {
        public DbSet<Members> Members { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<PaymentModel>PaymentModel{get;set;}

        public RentACarContext(DbContextOptions<RentACarContext> options) : base(options)
        {

        }
    }
}
