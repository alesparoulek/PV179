using PV179.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using JobsPortal.Infrastructure.EntityFramework.UnitOfWork;

namespace PV179
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new JobsPortalDbContext())
            {
                Console.WriteLine(db.Companies.First().Name);
                Console.WriteLine(db.Companies.First().Id);
                Console.WriteLine(db.Companies.Where(a => a.Login == "bcomp").ToList().First().Id);
                Console.WriteLine(db.Users.First().Id);
                Console.ReadLine();

                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "AAA",
                    LastName = "ABAB",
                    Email = "BBB",
                    Phone = "CCC",
                    Education = enums.Education.graduated_highschool
                };


                //var init = new MyInitializer();
              //  var unitofwork = new EntityFrameworkUnitOfWork(init.InitializeDatabase());
            }
        }
    }
}
