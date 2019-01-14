using System;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using NUnit.Framework;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.Config;
using JobsPortal.Infrastructure.EntityFramework;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Services;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects;

namespace JobsPortal.BL.Tests
{
    [TestFixture]
    public class CompanyTests
    {
        [Test]
        public async Task GetCompanyAccordingToName_ReturnsCoorectComapny()
        {
            var company = new CompanyDto()
            {
                Name = "aaa",
                Email = "aaaaac@bbb.com",

            };
            using (var db = Initializer.Provider.GetUnitOfWorkInstance())
            {
               
                var mapper = new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping));
                var repo = new EntityFrameworkRepository<Company>(Initializer.Provider);
                var repoUsr = new EntityFrameworkRepository<User>(Initializer.Provider);
                var repoJob = new EntityFrameworkRepository<JobOffer>(Initializer.Provider);
                var repoApp = new EntityFrameworkRepository<Application>(Initializer.Provider);
                var query2 = new EntityFrameworkQuery<Company>(Initializer.Provider);
                var query = new CompanyQueryObject(mapper, query2);
                var companyService = new CompanyService(mapper, repo, query);
                //var applyService = new ApplyService(mapper, repoUsr, repoJob, repoApp);
                //var companyFacade = new CompanyFacade(Initializer.Provider, companyService, applyService);
               // var comp = await companyFacade.GetCompanyAccordingToNameAsync("aaa");
                //Assert.AreEqual(company, comp);
            }
        }
    }
}
