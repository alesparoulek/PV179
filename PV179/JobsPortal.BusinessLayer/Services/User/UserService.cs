using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.BusinessLayer.Services.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure;
using JobsPortal.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public class UserService : CrudQueryServiceBase<User, UserDto, UserFilterDto>, IUserService
    {
        public UserService(IMapper mapper, IRepository<User> userRepository, QueryObjectBase<UserDto, User, UserFilterDto, IQuery<User>> userQueryObject)
            : base(mapper, userRepository, userQueryObject) { }

        protected override async Task<User> GetWithIncludesAsync(Guid entityId)
        {
            return await Repository.GetAsync(entityId);
        }

        public async Task<UserDto> GetUserAccordingToEmailAsync(string email)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto { Email = email });
            return queryResult.Items.SingleOrDefault();
        }

        
    }
}
