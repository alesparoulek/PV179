using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.Services.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using Utilities.Enums;
using JobsPortal.Infrastructure;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.Infrastructure.Query;

namespace JobsPortal.BusinessLayer.Services
{
    public class ApplyService :CrudQueryServiceBase<Application, ApplicationDto, ApplicationFilterDto>, IApplyService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<JobOffer> jobOfferRepository;
        private readonly IRepository<Application> applicationRepository;

        public ApplyService(IMapper mapper, IRepository<Application> applicationRepository, QueryObjectBase<ApplicationDto, Application, ApplicationFilterDto, IQuery<Application>> applicationQueryObject, IRepository<JobOffer> jobOfferRepository, IRepository<User> userRepository)
            : base(mapper, applicationRepository, applicationQueryObject)
        {
            this.applicationRepository = applicationRepository;
            this.userRepository = userRepository;
            this.jobOfferRepository = jobOfferRepository;
        }

        public async Task<Guid> ConfirmApplicationAsync(ApplicationDto applicationDto)
        {
            var application = Mapper.Map<Application>(applicationDto);

            var user = await userRepository.GetAsync(applicationDto.UserId);
            application.User = user ?? throw new ArgumentException("User must not be null");

            var jobOffer = await jobOfferRepository.GetAsync(applicationDto.JobOfferId);
            application.JobOffer = jobOffer ?? throw new ArgumentException("JobOffer must not be null");

            applicationRepository.Create(application);

            return application.Id;
        }

        public async Task<Application> GetApplicationById(Guid entityId)
        {
            return await applicationRepository.GetAsync(entityId);
        }

        public async Task<ApplicationDto> GetApplicationByIdDto(Guid entityId)
        {
            var application = await applicationRepository.GetAsync(entityId);
            var res = Mapper.Map<ApplicationDto>(application);
            return res;
        }

        public async Task<QueryResultDto<ApplicationDto, ApplicationFilterDto>> GetAllApplicationsForUser(
            ApplicationFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
        }

        public async Task<QueryResultDto<ApplicationDto, ApplicationFilterDto>> GetAllApplicationsOfJobOffer(
            ApplicationFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
        }

        public async Task ChangeApplicationJobOfferState(Guid id, JobOfferState jobOfferState)
        {
            var application = await GetApplicationById(id);
            
            application.JobOfferState =  jobOfferState;
            applicationRepository.Update(application);
        }

        public async Task ChangeApplicationUserState(Guid id, UserState userState)
        {
            var application = await GetApplicationById(id);
            application.UserState =  userState;
            applicationRepository.Update(application);
        }

        protected override async Task<Application> GetWithIncludesAsync(Guid entityId)
        {
            return await applicationRepository.GetAsync(entityId);
        }
    }
}
