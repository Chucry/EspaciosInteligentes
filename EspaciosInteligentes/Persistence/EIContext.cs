using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EspaciosInteligentes.Models;

namespace EspaciosInteligentes.Persistence
{
    public class EIContext : DbContext
    {
        public EIContext() : base("name=Default")
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}