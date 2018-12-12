using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
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

        Task<QueryResultDto<ApplicationDto, ApplicationFilterDto>> GetAllApplicationsForUser(
            ApplicationFilterDto filter);
        Task ChangeApplicationJobOfferState(Guid id, JobOfferState jobfferState);

        Task ChangeApplicationUserState(Guid id, UserState userState);



    }
}