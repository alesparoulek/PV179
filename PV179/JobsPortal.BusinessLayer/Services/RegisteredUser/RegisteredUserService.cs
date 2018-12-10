using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private const int PBKDF2IterCount = 100000;
        private const int PBKDF2SubkeyLength = 160 / 8;
        private const int saltSize = 128 / 8;

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


        public async Task<RegisteredUserDto> GetUserAccordingToLoginAsync(string login)
        {
            var queryResult = await registeredUserQueryObject.ExecuteQuery(new RegisteredUserFilterDto { Login = login });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<List<Application>> GetAllApplicationsForUserEmailOrId(Guid id)
        {
            var user = await GetWithIncludesAsync(id);
            return user.Applications;
        }

        public async Task<(bool success, string roles)> AuthorizeUserAsync(string login, string password)
        {
            var userResult = await registeredUserQueryObject.ExecuteQuery(new RegisteredUserFilterDto() { Login = login });
            var user = userResult.Items.SingleOrDefault();

            var succ = user != null && VerifyHashedPassword(user.PasswordHash, user.PasswordSalt, password);
            var roles = "User";
            return (succ, roles);
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

        private async Task<bool> GetIfUserExistsAsync(string login)
        {
            var queryResult = await registeredUserQueryObject.ExecuteQuery(new RegisteredUserFilterDto { Login = login});
            return (queryResult.Items.Count() == 1);
        }

        public async Task<Guid> RegisterUserAsync(UserCreateDto userDto)
        {
            var user = Mapper.Map<RegisteredUser>(userDto);

            if (await GetIfUserExistsAsync(user.Login))
            {
                throw new ArgumentException();
            }

            var password = CreateHash(userDto.Password);
            user.PasswordHash = password.Item1;
            user.PasswordSalt = password.Item2;

            registeredUserRepository.Create(user);

            return user.Id;
        }

        private Tuple<string, string> CreateHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, PBKDF2IterCount))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);

                return Tuple.Create(Convert.ToBase64String(subkey), Convert.ToBase64String(salt));
            }
        }

        private bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var saltBytes = Convert.FromBase64String(salt);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, PBKDF2IterCount))
            {
                var generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                return hashedPasswordBytes.SequenceEqual(generatedSubkey);
            }
        }


    }
}
