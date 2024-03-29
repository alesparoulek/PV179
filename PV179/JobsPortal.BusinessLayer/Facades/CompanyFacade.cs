﻿using JobsPortal.BusinessLayer.DataTransferObjects;
using Utilities.Enums;
using JobsPortal.BusinessLayer.Facades.Common;
using JobsPortal.BusinessLayer.Services;
using JobsPortal.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;

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

        public async Task<List<JobOffer>> GetCompaniesJobOffers(string name)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompaniesJobOffers(name);
            }
        }

        public async Task<List<JobOffer>> GetCompaniesJobOffers(Guid id)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompaniesJobOffers(id);
            }
        }

        public async Task<CompanyDto> GetCompanyAccordingToNameAsync(string name)
        {
            
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompanyAccordingToNameAsync(name);
            }
        }

        public async Task<CompanyDto> GetCompanyAccordingToIdAsync(Guid id)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetAccordingToId(id);
            }
        }

        public async Task<CompanyDto> GetCompanyAccordingToLoginAsync(string login)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetCompanyAccordingToLoginAsync(login);
            }
        }

        public async Task DeleteCompany(Guid id)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                comapnyService.Delete(id);
                await uow.Commit();
            }
        }

        public async Task ChangeApplicationJobOfferState(Guid id, JobOfferState jobOfferState)
        {
            using (var uow =UnitOfWorkProvider.Create())
            {
                await applyService.ChangeApplicationJobOfferState(id, jobOfferState);
                await uow.Commit();
            }
        }

        public async Task<QueryResultDto<CompanyDto, CompanyFilterDto>> GetAllCompanies(CompanyFilterDto filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await comapnyService.GetAllCompanies(filter);
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

        public async Task<QueryResultDto<JobOfferDto, JobOfferFilterDto>> GetAllJobOffersForCompany(JobOfferFilterDto filter)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return await jobOfferService.GetAllJobOffersForCompany(filter);
            }
        }
    }
}
