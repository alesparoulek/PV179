using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.BusinessLayer.Services.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure;
using JobsPortal.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public class CompanyService : CrudQueryServiceBase<Company, CompanyDto, CompanyFilterDto>, ICompanyService
    {
        public CompanyService(IMapper mapper, IRepository<Company> customerRepository, QueryObjectBase<CompanyDto, Company, CompanyFilterDto, IQuery<Company>> companyQueryObject)
            : base(mapper, customerRepository, companyQueryObject) { }

        protected override async Task<Company> GetWithIncludesAsync(Guid entityId)
        {
            return await Repository.GetAsync(entityId);
        }
        
        public async Task<CompanyDto> GetCompanyAccordingToNameAsync(string name)
        {
            var queryResult = await Query.ExecuteQuery(new CompanyFilterDto { Name = name });
            return queryResult.Items.SingleOrDefault();
        }
    }
}
