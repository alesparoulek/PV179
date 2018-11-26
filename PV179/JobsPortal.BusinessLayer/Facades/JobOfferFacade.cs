using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.Facades.Common;
using JobsPortal.BusinessLayer.Services;
using JobsPortal.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;

namespace JobsPortal.BusinessLayer.Facades
{
    public class JobOfferFacade : FacadeBase
    { 
        private readonly IJobOfferService jobOfferService;
        private readonly IApplyService applyService;
        
        public JobOfferFacade(IUnitOfWorkProvider unitOfWorkProvider, IJobOfferService jobOfferService, IApplyService applyService) : base(unitOfWorkProvider)
        {
            this.jobOfferService = jobOfferService;
            this.applyService = applyService;
        }


        //public async Task<QueryResultDto<JobOfferDto, JobOfferFilterDto>> GetJobOffersAsync(JobOfferFilterDto filter, bool includeCurrentlyAvailableUnits = true)
        

        public async Task<Guid> CreateJobOffer(JobOfferDto jobOfferDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var jobOfferId = jobOfferService.Create(jobOfferDto);
                await uow.Commit();
                return jobOfferId;
            }
        }

        public async Task<bool> DeleteJobOffer(Guid id)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                if ((await jobOfferService.GetAsync(id, false)) == null)
                {
                    return false;
                }
                jobOfferService.Delete(id);
                await uow.Commit();
                return true;
            }
        }

        public async Task<bool> EditJobOfferAsync(JobOfferDto jobOfferDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                if ((await jobOfferService.GetAsync(jobOfferDto.Id, false)) == null)
                {
                    return false;
                }
                await jobOfferService.Update(jobOfferDto);
                await uow.Commit();
                return true;
            }
        }

        public async Task<QueryResultDto<JobOfferDto, JobOfferFilterDto>> ListFilteredJobsAsync(JobOfferFilterDto filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await jobOfferService.ListFilteredJobsAsync(filter);
            }
        }

        public async Task<Guid> ConfirmApplicationAsync(ApplicationDto applicationDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var applicationId = applyService.ConfirmApplicationAsync(applicationDto);
                await uow.Commit();
                return await applicationId;
            }
        
        }

        public async Task<JobOfferDto> GetJobOfferByIdAsync(Guid id)
        {
            using (UnitOfWorkProvider.Create())
            {
                var jobOffer = await jobOfferService.GetAsync(id);
                return jobOffer;
            }
        }
    }
}
