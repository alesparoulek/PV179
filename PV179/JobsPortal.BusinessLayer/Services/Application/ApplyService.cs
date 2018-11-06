using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Services.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
using JobsPortal.Infrastructure;
namespace JobsPortal.BusinessLayer.Services
{
    public class ApplyService : ServiceBase, IApplyService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<JobOffer> jobOfferRepository;
        private readonly IRepository<Application> applicationRepository;

        public ApplyService(IMapper mapper, IRepository<User> userRepository, IRepository<JobOffer> jobOfferRepository, IRepository<Application> applicationRepository)
            : base(mapper)
        {
            this.userRepository = userRepository;
            this.jobOfferRepository = jobOfferRepository;
            this.applicationRepository = applicationRepository;
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

        public async Task ChangeApplicationJobOfferState(Guid id, JobOfferState jobofferState)
        {
            var application = await GetApplicationById(id);
            application.JobOfferState = jobofferState;
            applicationRepository.Update(application);
        }

        public async Task ChangeApplicationUserState(Guid id, UserState userState)
        {
            var application = await GetApplicationById(id);
            application.UserState = userState;
            applicationRepository.Update(application);
        }
    }
}
