using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetCompanyAccordingToNameAsync(string name);

        Task<List<JobOffer>> GetCompaniesJobOffers(string name);
        Task<List<JobOffer>> GetCompaniesJobOffers(Guid id);


        Task<JobOfferDto> GetAsync(Guid entityId, bool withIncludes = true);
    }

   
   
}
