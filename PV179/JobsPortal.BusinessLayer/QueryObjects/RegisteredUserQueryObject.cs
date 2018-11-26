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
    public class RegisteredUserQueryObject : QueryObjectBase<RegisteredUserDto, RegisteredUser, RegisteredUserFilterDto, IQuery<RegisteredUser>>
    {
        public RegisteredUserQueryObject(IMapper mapper, IQuery<RegisteredUser> query) : base(mapper, query) { }

        protected override IQuery<RegisteredUser> ApplyWhereClause(IQuery<RegisteredUser> query, RegisteredUserFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Email) && string.IsNullOrWhiteSpace(filter.Login))
            {
                return query;
            }

            if (filter.Login != null)
            {
                return query.Where(new SimplePredicate(nameof(RegisteredUser.Login), ValueComparingOperator.Equal, filter.Login));
            }

            return query.Where(new SimplePredicate(nameof(RegisteredUser.Email), ValueComparingOperator.Equal, filter.Email));
        }
    }
}
