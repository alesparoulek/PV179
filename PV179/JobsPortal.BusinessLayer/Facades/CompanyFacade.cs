using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
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

        public CompanyFacade(IUnitOfWorkProvider unitOfWorkProvider, ICompanyService companyService, IApplyService applyService) : base(unitOfWorkProvider)
        {
            this.comapnyService = companyService;
            this.applyService = applyService;
        }

        public async Task<CompanyDto> GetCompanyAccordingToNameAsync(string name)
        {
            
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompanyAccordingToNameAsync(name);
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
    }
}
