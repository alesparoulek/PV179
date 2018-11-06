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
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;

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

        public async Task<UserDto> GetUserAccordingToEmailAsync(string email)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await userService.GetUserAccordingToEmailAsync(email);
            }
        }
   
        public async Task ChangeApplicationUserState(Guid id, UserState userState)
        {
            using (UnitOfWorkProvider.Create())
            {
                await applyService.ChangeApplicationUserState(id, userState);
            }
        }


        public async Task<List<Application>> GetAllApplicationsForUserEmailOrId(Guid id)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return await registeredUserService.GetAllApplicationsForUserEmailOrId(id);
            }
        }







    }
}
