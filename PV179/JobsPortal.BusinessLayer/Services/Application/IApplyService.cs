using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.DataAccessLayer.EntityFramework.Enums;

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
    }
}