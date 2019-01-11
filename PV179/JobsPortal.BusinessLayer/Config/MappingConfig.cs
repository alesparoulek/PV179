using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure.Query;

namespace JobsPortal.BusinessLayer.Config
{
    public class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDto>().ReverseMap();
            config.CreateMap<Application, ApplicationDto>().ReverseMap();
            config.CreateMap<JobOffer, JobOfferDto>().ReverseMap();
            config.CreateMap<Company, CompanyDto>().ReverseMap();
            config.CreateMap<RegisteredUser, RegisteredUserDto>().ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, UserFilterDto>>();
            config.CreateMap<QueryResult<JobOffer>, QueryResultDto<JobOfferDto, JobOfferFilterDto>>();
            config.CreateMap<QueryResult<Company>, QueryResultDto<CompanyDto, CompanyFilterDto>>();
            config.CreateMap<QueryResult<RegisteredUser>, QueryResultDto<RegisteredUserDto, RegisteredUserFilterDto>>();
            config.CreateMap<QueryResult<Application>, QueryResultDto<ApplicationDto, ApplicationFilterDto>>();
            config.CreateMap<UserCreateDto, RegisteredUser>().ConvertUsing(converter => new RegisteredUser()
            {
                Login = converter.Login,
                FirstName = converter.FirstName,
                LastName = converter.LastName,
                Email = converter.Email,
                Phone = converter.Phone
            });
            config.CreateMap<CompanyCreateDto, Company>().ReverseMap();
            config.CreateMap<JobOfferCreateDto, JobOffer>().ReverseMap();
        }

    }
}