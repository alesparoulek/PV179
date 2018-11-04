using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BL.Tests
{
    [TestFixture]
    public class CompanyTests
    {
        [Test]
        public async Task GetCompanyAccordingToName_ReturnsCoorectComapny()
        {
            var company = new Company()
            {
                Name = "aaa",
                Email = "a@bbb.com",
                Login = "b",
                Password = "c",
                Offers = new List<JobOffer>()
            };

            var queryRes = await 

        }
    }
}
