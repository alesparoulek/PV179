using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Facades.Common;
using JobsPortal.BusinessLayer.Services;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using Utilities.Enums;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;

namespace JobsPortal.BusinessLayer.Facades
{
    public class UserFacade : FacadeBase
    {
        private readonly IUserService userService;
        private readonly IApplyService applyService;
        private readonly IRegisteredUserService registeredUserService;

        public UserFacade(IUnitOfWorkProvider unitOfWorkProvider, IUserService userService, IApplyService applyService, IRegisteredUserService registeredUserService) : base(unitOfWorkProvider)
        {
            this.userService = userService;
            this.applyService = applyService;
            this.registeredUserService = registeredUserService;
        }

        public async Task<(bool success, string roles)> Login(string username, string password)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await registeredUserService.AuthorizeUserAsync(username, password);
            }
        }

        public async Task<UserDto> GetUserAccordingToId(Guid id)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await registeredUserService.GetAccordingToId(id);
            }
        }
        public async Task<UserDto> GetUserAccordingToEmailAsync(string email)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await registeredUserService.GetUserAccordingToEmailAsync(email);
            }
        }

        public async Task<UserDto> GetUserAccordingToLoginAsync(string login)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await registeredUserService.GetUserAccordingToLoginAsync(login);
            }
        }

        public async Task ChangeApplicationUserState(Guid id, UserState userState)
        {
            using (UnitOfWorkProvider.Create())
            {
                await applyService.ChangeApplicationUserState(id, userState);
            }
        }


        public async Task<QueryResultDto<ApplicationDto, ApplicationFilterDto>> GetAllApplicationsForUser(ApplicationFilterDto filter)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return await applyService.GetAllApplicationsForUser(filter);
            }
        }

        public async Task<Guid> RegisterUser(UserCreateDto userCreateDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                try
                {
                    var id = await registeredUserService.RegisterUserAsync(userCreateDto);
                    await uow.Commit();
                    return id;
                }
                catch (ArgumentException)
                {
                    throw;
                }
            }
        }

    }
}
