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

        Guid Create(UserDto entityDto);

        Task Update(UserDto entityDto);

        void Delete(Guid entityId);

        Task<UserDto> GetAsync(Guid entityId, bool withIncludes = true);
    }
}
