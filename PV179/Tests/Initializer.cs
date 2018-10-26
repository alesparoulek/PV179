using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using JobsPortal.Infrastructure.EntityFramework.UnitOfWork;
using JobsPortal.Infrastructure.UnitOfWork;
using NUnit.Framework;
using PV179;
using PV179.entities;

namespace Tests
{
    [SetUpFixture]
    public class Initializer
    {
        private const string TestDbConnectionString = "InMemoryTest";

        internal static readonly IUnitOfWorkProvider Provider = new EntityFrameworkUnitOfWorkProvider(InitializeDatabase);

        /// <summary>
        /// Initializes all Business Layer tests
        /// </summary>
        [OneTimeSetUp]
        public void InitializeBusinessLayerTests()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
        }

        private static DbContext InitializeDatabase()
        {
            var context = new MyDbContext(Effort.DbConnectionFactory.CreatePersistent(TestDbConnectionString));
            context.Applications.RemoveRange(context.Applications);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            var user = new User()
            {
                FirstName = "Franta",
                LastName = "Kuldanu",
                Email = "frantakuldanu@seznam.cz",
                Phone = "0609112567",
                Education = PV179.enums.Education.graduated_highschool
            };

            context.Users.AddOrUpdate(user);
            

            context.SaveChanges();

            return context;
        }
    }
}
