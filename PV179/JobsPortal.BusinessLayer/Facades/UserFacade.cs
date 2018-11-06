using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Facades.Common;
using JobsPortal.BusinessLayer.Services;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure.UnitOfWork;
using JobsPortal.BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Facades
{
    public class UserFacade : FacadeBase
    {
        private readonly IUserService userService;
        private readonly IApplyService applyService;

        public UserFacade(IUnitOfWorkProvider unitOfWorkProvider, IUserService userService, IApplyService applyService) : base(unitOfWorkProvider)
        {
            this.userService = userService;
            this.applyService = applyService;
        }

        public async Task<UserDto> GetUserAccordingToEmailAsync(string email)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await userService.GetUserAccordingToEmailAsync(email);
            }
        }
   
        public async Task ChangeApplicationUserState(UserStateertae us)
        {dfag
            gadfga;
        }

        public async Task Changeblabla(Us)




    }
}
