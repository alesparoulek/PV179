using System;
using System.Linq;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;

namespace JobsPortal.DataAccessLayer.EntityFramework
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
                    Education = Enums.Education.graduatedHighschool
                };

                
            }
        }
    }
}
