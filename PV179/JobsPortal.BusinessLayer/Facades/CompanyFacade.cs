using JobsPortal.BusinessLayer.DataTransferObjects;
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

        public CompanyFacade(IUnitOfWorkProvider unitOfWorkProvider, ICompanyService companyService) : base(unitOfWorkProvider)
        {
            this.comapnyService = companyService;
        }

        public async Task<CompanyDto> GetCompanyAccordingToNameAsync(string name)
        {
            
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompanyAccordingToNameAsync(name);
            }
        }
    }
}
