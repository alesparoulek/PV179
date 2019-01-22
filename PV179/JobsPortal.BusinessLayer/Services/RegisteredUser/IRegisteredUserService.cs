using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IRegisteredUserService
    {
        Task<RegisteredUserDto> GetUserAccordingToEmailAsync(string email);
        Task<Guid> RegisterUserAsync(UserCreateDto user);
        Task<(bool success, string roles)> AuthorizeUserAsync(string username, string password);
        Task<RegisteredUserDto> GetUserAccordingToLoginAsync(string login);
        Task<RegisteredUserDto> GetAccordingToId(Guid id);
        Task<QueryResultDto<RegisteredUserDto, RegisteredUserFilterDto>> GetAllUsers(RegisteredUserFilterDto filter);
        Guid Create(RegisteredUserDto entityDto);
        Task Update(RegisteredUserDto entityDto);
        void Delete(Guid entityId);
    }
}
