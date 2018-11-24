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
    public class RegisteredUserService : ServiceBase, IRegisteredUserService
    {
        private readonly IRepository<RegisteredUser> registeredUserRepository;
        private readonly QueryObjectBase<RegisteredUserDto, RegisteredUser, RegisteredUserFilterDto, IQuery<RegisteredUser>> registeredUserQueryObject;

        public RegisteredUserService(IMapper mapper, IRepository<RegisteredUser> registeredUserRepository, QueryObjectBase<RegisteredUserDto, RegisteredUser, RegisteredUserFilterDto, IQuery<RegisteredUser>> registeredUserQueryObject)
            : base(mapper)
        {
            this.registeredUserRepository = registeredUserRepository;
            this.registeredUserQueryObject = registeredUserQueryObject;
        }

        public async Task<RegisteredUserDto> GetUserAccordingToEmailAsync(string email)
        {
            var queryResult = await registeredUserQueryObject.ExecuteQuery(new RegisteredUserFilterDto { Email = email });
            return queryResult.Items.SingleOrDefault();
        }

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
        
        public async Task<RegisteredUser> GetWithIncludesAsync(Guid entityId)
        {
            return await registeredUserRepository.GetAsync(entityId);
        }

        private async Task<bool> GetIfUserExistsAsync(string email)
        {
            var queryResult = await registeredUserQueryObject.ExecuteQuery(new RegisteredUserFilterDto { Email = email });
            return (queryResult.Items.Count() == 1);
        }

        public async Task<Guid> RegisterUserAsync(UserCreateDto userDto)
        {
            var user = Mapper.Map<RegisteredUser>(userDto);

            if (await GetIfUserExistsAsync(user.Email))
            {
                throw new ArgumentException();
            }

            registeredUserRepository.Create(user);

            return user.Id;
        }



    }
}
