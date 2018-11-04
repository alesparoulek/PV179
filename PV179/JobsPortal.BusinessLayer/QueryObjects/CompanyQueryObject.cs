using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure.Query;
using JobsPortal.Infrastructure.Query.Predicates;
using JobsPortal.Infrastructure.Query.Predicates.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.QueryObjects
{
    public class CompanyQueryObject : QueryObjectBase <CompanyDto, Company, CompanyFilterDto, IQuery<Company>>
    {
        public CompanyQueryObject(IMapper mapper, IQuery<Company> query) : base(mapper, query) { }

        protected override IQuery<Company> ApplyWhereClause(IQuery<Company> query, CompanyFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Name))
            {
                return query;
            }
            return query.Where(new SimplePredicate(nameof(Company.Name), ValueComparingOperator.Equal, filter.Name));
        }
    }
}
