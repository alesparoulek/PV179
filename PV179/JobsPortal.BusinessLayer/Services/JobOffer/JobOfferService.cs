using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
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
    public class JobOfferService : CrudQueryServiceBase<JobOffer, JobOfferDto, JobOfferFilterDto>, IJobOfferService
    {
        public JobOfferService(IMapper mapper, IRepository<JobOffer> jobOfferRepository, QueryObjectBase<JobOfferDto, JobOffer, JobOfferFilterDto, IQuery<JobOffer>> jobOfferQueryObject)
            : base(mapper, jobOfferRepository, jobOfferQueryObject) { }


        protected async override Task<JobOffer> GetWithIncludesAsync(Guid entityId)
        {
            return await Repository.GetAsync(entityId);
        }

        public async Task<QueryResultDto<JobOfferDto, JobOfferFilterDto>> ListFilteredJobsAsync(JobOfferFilterDto filter)
        {
            var queryres = await Query.ExecuteQuery(filter);
            return queryres;
        }

        


    }
}
