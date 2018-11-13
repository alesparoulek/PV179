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

        Guid Create(CompanyDto entityDto);

        Task Update(CompanyDto entityDto);

        void Delete(Guid entityId);

        Task<CompanyDto> GetAsync(Guid entityId, bool withIncludes = true);

    }

   
   
}
