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
        Task<RegisteredUserDto> GetUserAccordingToEmailAsync(string email);
        Task<Guid> RegisterUserAsync(UserCreateDto user);
        Task<List<Application>> GetAllApplicationsForUserEmailOrId(Guid id);
        Task<(bool success, string roles)> AuthorizeUserAsync(string username, string password);
        Task<RegisteredUserDto> GetUserAccordingToLoginAsync(string login);

    }
}
