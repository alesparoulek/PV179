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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public class CompanyService : CrudQueryServiceBase<Company, CompanyDto, CompanyFilterDto>, ICompanyService
    {
        private const int PBKDF2IterCount = 100000;
        private const int PBKDF2SubkeyLength = 160 / 8;
        private const int saltSize = 128 / 8;

        private readonly IRepository<Company> companyRepository;
        private readonly QueryObjectBase<CompanyDto, Company, CompanyFilterDto, IQuery<Company>> companyQueryObject;

        public CompanyService(IMapper mapper, IRepository<Company> companyRepository,
            QueryObjectBase<CompanyDto, Company, CompanyFilterDto, IQuery<Company>> companyQueryObject)
            : base(mapper, companyRepository, companyQueryObject)
        {
            this.companyRepository = companyRepository;
            this.companyQueryObject = companyQueryObject;
        }

        protected override async Task<Company> GetWithIncludesAsync(Guid entityId)
        {
            return await Repository.GetAsync(entityId);
        }
        
        public async Task<CompanyDto> GetCompanyAccordingToNameAsync(string name)
        {
            var queryResult = await Query.ExecuteQuery(new CompanyFilterDto { Name = name });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<CompanyDto> GetCompanyAccordingToLoginAsync(string login)
        {
            var queryResult = await Query.ExecuteQuery(new CompanyFilterDto { Login = login});
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<List<JobOffer>> GetCompaniesJobOffers(string name)
        {
            var comp = await GetCompanyAccordingToNameAsync(name);
            return comp.Offers;
        }

        public async Task<List<JobOffer>> GetCompaniesJobOffers(Guid id)
        {
            var comp = await GetWithIncludesAsync(id);
            return comp.Offers;
        }

        public async Task<(bool success, string roles)> AuthorizeCompanyAsync(string login, string password)
        {
            var compResult = await companyQueryObject.ExecuteQuery(new CompanyFilterDto() { Login = login });
            var comp = compResult.Items.SingleOrDefault();

            var succ = comp != null && VerifyHashedPassword(comp.PasswordHash, comp.PasswordSalt, password);
            var roles = "Company";
            return (succ, roles);
        }

        private async Task<bool> GetIfCompanyExistsAsync(string login)
        {
            var queryResult = await companyQueryObject.ExecuteQuery(new CompanyFilterDto { Login = login });
            return (queryResult.Items.Count() == 1);
        }


        public async Task<Guid> RegisterCompanyAsync(CompanyCreateDto companyDto)
        {
            var company = Mapper.Map<Company>(companyDto);

            if (await GetIfCompanyExistsAsync(companyDto.Login))
            {
                throw new ArgumentException();
            }

            var password = CreateHash(companyDto.Password);
            company.PasswordHash = password.Item1;
            company.PasswordSalt = password.Item2;

            companyRepository.Create(company);

            return company.Id;
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
