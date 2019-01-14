using JobsPortal.BusinessLayer.DataTransferObjects;
using Utilities.Enums;
using JobsPortal.BusinessLayer.Facades.Common;
using JobsPortal.BusinessLayer.Services;
using JobsPortal.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Facades
{
    public class CompanyFacade : FacadeBase
    {
        private readonly ICompanyService comapnyService;
        private readonly IApplyService applyService;
        private readonly IJobOfferService jobOfferService;
        public CompanyFacade(IUnitOfWorkProvider unitOfWorkProvider, ICompanyService companyService, IApplyService applyService, IJobOfferService jobOfferService) : base(unitOfWorkProvider)
        {
            this.comapnyService = companyService;
            this.jobOfferService = jobOfferService;
            this.applyService = applyService;
        }

        public async Task<CompanyDto> GetCompanyAccordingToNameAsync(string name)
        {
            
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompanyAccordingToNameAsync(name);
            }
        }

        public async Task<CompanyDto> GetCompanyAccordingToLoginAsync(string login)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompanyAccordingToLoginAsync(login);
            }
        }


        public async Task ChangeApplicationJobOfferState(Guid id, JobOfferState jobOfferState)
        {
            using (UnitOfWorkProvider.Create())
            {
                await applyService.ChangeApplicationJobOfferState(id, jobOfferState);
            }
        }

        public async Task<Guid> RegisterCompany(CompanyCreateDto company)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                try
                {
                    var id = await comapnyService.RegisterCompanyAsync(company);
                    await uow.Commit();
                    return id;
                }
                catch (ArgumentException)
                {
                    throw;
                }
            }
        }
        public async Task<(bool success, string roles)> Login(string login, string password)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.AuthorizeCompanyAsync(login, password);
            }
        }

        public async Task<Guid> CreateJobOffer(JobOfferCreateDto jobOfferCreateDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var id = await jobOfferService.CreateJobOffer(jobOfferCreateDto);
                await uow.Commit();
                return id;
            }
        }
    }
}
