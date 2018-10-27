using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace JobsPortal.DataAccessLayer.EntityFramework
{
    public class JobsPortalInitializer : DropCreateDatabaseAlways<JobsPortalDbContext>
    {
        protected override void Seed(JobsPortalDbContext context)
        {
            context.Companies.Add(new Company
            {
                Id = Guid.NewGuid(),
                Login = "acomp",
                Name = "Alpha Company",
                Email = "acomp@acomp.acomp",
                Password = "acomp",
                Offers = null               
            });

            context.Companies.Add(new Company
            {
                Id = Guid.Parse("aa04dc65-5c07-40fe-a916-175165b9b90f"),
                Login = "bcomp",
                Name = "Beta Company",
                Email = "bcomp@bcomp.bcomp",
                Password = "bcomp",
                Offers = null
            });

            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Franta",
                LastName = "Kuldanu",
                Email = "frantakuldanu@seznam.cz",
                Phone = "0609112567",
                Education = Enums.Education.graduated_highschool
            });

            context.JobOffers.Add(new JobOffer
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse("aa04dc65-5c07-40fe-a916-175165b9b90f"),
                JobType = Enums.JobType.InformationTechnology,
                Name = "C# programmer",
                Description = "programming a jobs portal in C#",
                TimeJob = Enums.TimeJob.fulltime,
                Location = Enums.Location.Jihomoravsky,
                Education = Enums.Education.graduated_highschool,
                Salary = 0,
                Questionnaire = new List<string>(new string[] { "Are you ready to rock?"}),
                Applications = null,
                Date = DateTime.Parse("2018-10-07")
            });

            base.Seed(context);
        }
    }
}
