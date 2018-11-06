using JobsPortal.BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAccordingToEmailAsync(string email);

        Guid Create(JobOfferDto entityDto);

        Task Update(JobOfferDto entityDto);

        Task Delete(Guid entityId);

        Task<JobOfferDto> GetAsync(Guid entityId, bool withIncludes = true);
    }
}
