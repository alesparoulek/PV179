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

namespace JobsPortal.BusinessLayer.Facades
{
    public class UserFacade : FacadeBase
    {
        private readonly IUserService userService;

        public UserFacade(IUnitOfWorkProvider unitOfWorkProvider, IUserService userService) : base(unitOfWorkProvider)
        {
            this.userService = userService;
        }

        public async Task<UserDto> GetUserAccordingToEmailAsync(string email)
        {

            using (UnitOfWorkProvider.Create())
            {
                return await userService.GetUserAccordingToEmailAsync(email);
            }
        }
    }
}
