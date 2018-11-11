using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IRegisteredUserService
    {
        Task<List<Application>> GetAllApplicationsForUserEmailOrId(Guid id);

        Task<List<Application>> GetAllApplicationsForUserEmailOrId(string email);

        Guid Create(JobOfferDto entityDto);

        Task Update(JobOfferDto entityDto);

        Task Delete(Guid entityId);

        Task<JobOfferDto> GetAsync(Guid entityId, bool withIncludes = true);
    }
}
