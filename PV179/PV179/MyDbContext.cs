using PV179.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179
{
    public class MyDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext() : base("PV179")
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
