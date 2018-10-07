using PV179.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179
{
    public class MyInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Companies.Add(new Company
            {
                Login = "acomp",
                Name = "Alpha Company",
                Email = "acomp@acomp.acomp",
                Password = "acomp",
                Offers = null               
            });

            context.Companies.Add(new Company
            {
                Login = "bcomp",
                Name = "Beta Company",
                Email = "bcomp@bcomp.bcomp",
                Password = "bcomp",
                Offers = null
            });

            context.Users.Add(new User
            {
                Name = "Franta Kuldanu",
                Email = "frantakuldanu@seznam.cz",
                Phone = "0609112567",
                Education = enums.Education.graduated_highschool
            });

            context.JobOffers.Add(new JobOffer
            {
                CompanyId = 1,
                JobType = enums.JobType.InformationTechnology,
                Name = "C# programmer",
                Description = "programming a jobs portal in C#",
                TimeJob = enums.TimeJob.fulltime,
                Location = enums.Location.Jihomoravsky,
                Education = enums.Education.graduated_highschool,
                Salary = 0,
                Questionnaire = new List<string>(new string[] { "Are you ready to rock?"}),
                Applications = null,
                Date = DateTime.Parse("2018-10-07")
            });

            base.Seed(context);
        }
    }
}
