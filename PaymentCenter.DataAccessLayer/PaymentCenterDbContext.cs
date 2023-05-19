using Microsoft.EntityFrameworkCore;
using PaymentCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCenter.DataAccessLayer
{
    public class PaymentCenterDbContext : DbContext
    {
        public DbSet<BoxOfficeAttendant> BoxOfficeAttendants { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionSubscriber> InstitutionSubscribers { get; set; }
        public DbSet<InstitutionType> InstitutionTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PaymentCenterDB;Trusted_Connection=true");
            }
        }

    }
}
