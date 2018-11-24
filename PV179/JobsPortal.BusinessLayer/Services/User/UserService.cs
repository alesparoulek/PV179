using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
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
        public UserService(IMapper mapper, IRepository<User> customerRepository, QueryObjectBase<UserDto, User, UserFilterDto, IQuery<User>> customerQueryObject)
            : base(mapper, customerRepository, customerQueryObject) { }

        protected override async Task<User> GetWithIncludesAsync(Guid entityId)
        {
            return await Repository.GetAsync(entityId);
        }

        /// <summary>
        /// Gets customer with given email address
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>Customer with given email address</returns>
        public async Task<UserDto> GetCustomerAccordingToEmailAsync(string email)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto { Email = email });
            return queryResult.Items.SingleOrDefault();
        }

        /*
        public async Task<QueryResultDto<UserDto, UserFilterDto>> ListOnlyAllUsersAsync()
        {
            var x = await Query.ExecuteQuery(new UserFilterDto { Email = null });
            return x;
        }*/
    }
}
