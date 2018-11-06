using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IJobOfferService
    {
        Task<QueryResultDto<JobOfferDto, JobOfferFilterDto>> ListFilteredJobsAsync(JobOfferFilterDto filter);
        
        Guid Create(JobOfferDto entityDto);
        
        Task Update(JobOfferDto entityDto);

        Task Delete(Guid entityId);
        
        Task<JobOfferDto> GetAsync(Guid entityId, bool withIncludes = true);

    }
}
