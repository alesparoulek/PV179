using PV179.entities;
using System.Data.Common;
using System.Data.Entity;


namespace PV179
{
    public class JobsPortalDbContext : DbContext
    {
        private const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Database=Jobs;Trusted_Connection=True;MultipleActiveResultSets=true";


        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public JobsPortalDbContext() : base(ConnectionString)
        {
            Database.SetInitializer(new JobsPortalInitializer());
        }

        public JobsPortalDbContext(DbConnection connection) : base(connection, true)
        {
            Database.CreateIfNotExists();
        }
    }
}
