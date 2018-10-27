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
            /*
            config.CreateMap<Product, ProductDto>();
            config.CreateMap<ProductDto, Product>().ForMember(dest => dest.Category, opt => opt.Ignore());
            config.CreateMap<Category, CategoryDto>().ForMember(categoryDto => categoryDto.CategoryPath, opts => opts.ResolveUsing(category =>
            {
                var categoryPath = category.Name;
                while (category.Parent != null)
                {
                    categoryPath = category.Parent.Name + "/" + categoryPath;
                    category = category.Parent;
                }
                return categoryPath;
            })).ReverseMap();
            config.CreateMap<Order, OrderDto>().ReverseMap();
            config.CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            config.CreateMap<Customer, CustomerDto>().ReverseMap();
            config.CreateMap<QueryResult<Product>, QueryResultDto<ProductDto, ProductFilterDto>>();
            config.CreateMap<QueryResult<Category>, QueryResultDto<CategoryDto, CategoryFilterDto>>();
            config.CreateMap<QueryResult<Order>, QueryResultDto<OrderDto, OrderFilterDto>>();
            config.CreateMap<QueryResult<OrderItem>, QueryResultDto<OrderItemDto, OrderItemFilterDto>>();
            config.CreateMap<QueryResult<Customer>, QueryResultDto<CustomerDto, CustomerFilterDto>>();
            */
        }

    }
}