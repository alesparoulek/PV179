using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace JobsPortal.DataAccessLayer.EntityFramework
{
    public class JobsPortalInitializer : CreateDatabaseIfNotExists<JobsPortalDbContext>
    {
        protected override void Seed(JobsPortalDbContext context)
        {
            context.Companies.Add(new Company
            {
                Id = Guid.NewGuid(),
                Login = "acomp",
                Name = "Alpha Company",
                Email = "acomp@acomp.acomp",
                PasswordSalt = "bMVo7iOysuxmTZtzHOKx2Q==",
                PasswordHash = "Avhypra2fElqEN3TBUpTh8W2l+o=",
                Offers = null               
            });

            context.Companies.Add(new Company
            {
                Id = Guid.Parse("aa04dc65-5c07-40fe-a916-175165b9b90f"),
                Login = "bcomp",
                Name = "Beta Company",
                Email = "bcomp@bcomp.bcomp",
                PasswordSalt = "bMVo7iOysuxmTZtzHOKx2Q==",
                PasswordHash = "Avhypra2fElqEN3TBUpTh8W2l+o=",
                Offers = null
            });

            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Franta",
                LastName = "Kuldanu",
                Email = "frantakuldanu@seznam.cz",
                Phone = "0609112567",
                Education = Utilities.Enums.Education.GraduatedHighschool
            });

            context.RegisteredUsers.Add(new RegisteredUser
            {
                Id = Guid.NewGuid(),
                FirstName = "admin",
                LastName = "admin",
                Login = "admin",
                PasswordHash = "9P/rV93VYQ1dq80nCk20XcZPHck=",
                PasswordSalt = "hsbs67bR+KH6YxDYpQEY3w==",
                Email = "admin@admin.admin",
                Phone = "0000000000",
                Education = Utilities.Enums.Education.Any
            });

            context.JobOffers.Add(new JobOffer
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse("aa04dc65-5c07-40fe-a916-175165b9b90f"),
                JobType = Utilities.Enums.JobType.InformationTechnology,
                Name = "C# programmer",
                Description = "programming a jobs portal in C#",
                TimeJob = Utilities.Enums.TimeJob.Fulltime,
                Location = Utilities.Enums.Location.Jihomoravsky,
                Education = Utilities.Enums.Education.GraduatedHighschool,
                Salary = 0,
                Questionnaire = "AAAAAA/BBBBB/CCCCCC/DDDDDD",
                Applications = null,
                Date = DateTime.Parse("2018-10-07")
            });

            base.Seed(context);
        }
    }
}
