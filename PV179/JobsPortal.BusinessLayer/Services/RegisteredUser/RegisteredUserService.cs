using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.BusinessLayer.Services.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure;
using JobsPortal.Infrastructure.Query;

namespace JobsPortal.BusinessLayer.Services
{
    public class RegisteredUserService : CrudQueryServiceBase<RegisteredUser, RegisteredUserDto, RegisteredUserFilterDto>, IRegisteredUserService
    {
        public RegisteredUserService(IMapper mapper, IRepository<RegisteredUser> registeredUserRepository, QueryObjectBase<RegisteredUserDto, RegisteredUser, RegisteredUserFilterDto, IQuery<RegisteredUser>> registeredUserListQuery)
            : base(mapper, registeredUserRepository, registeredUserListQuery) { }


        public async Task<List<Application>> GetAllApplicationsForUserEmailOrId(Guid id)
        {
            var user = await GetWithIncludesAsync(id);
            return user.Applications;
        }

        public async Task<List<Application>> GetAllApplicationsForUserEmailOrId(string email)
        {
            var user = await GetUserAccordingToEmailAsync(email);
            return user.Applications;
        }

        protected async override Task<RegisteredUser> GetWithIncludesAsync(Guid entityId)
        {
            return await Repository.GetAsync(entityId);
        }

        public async Task<RegisteredUserDto> GetUserAccordingToEmailAsync(string email)
        {
            var queryResult = await Query.ExecuteQuery(new RegisteredUserFilterDto { Email = email });
            return queryResult.Items.SingleOrDefault();
        }

    }
}
