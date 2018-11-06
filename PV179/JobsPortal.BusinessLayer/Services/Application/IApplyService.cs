﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IApplyService
    {
        /// <summary>
        /// Persists order together with all related data
        /// </summary>
        /// <param name="createOrderDto">wrapper for order, orderItems, customer and coupon</param>
        Task<Guid> ConfirmApplicationAsync(ApplicationDto applicationDto);

        Task<Application> GetApplicationById(Guid entityId);

        Task ChangeApplicationJobOfferState(Guid id, JobOfferState jobfferState);

        Task ChangeApplicationUserState(Guid id, UserState userState);

        Guid Create(JobOfferDto entityDto);

        Task Update(JobOfferDto entityDto);

        Task Delete(Guid entityId);

        Task<JobOfferDto> GetAsync(Guid entityId, bool withIncludes = true);
    }
}