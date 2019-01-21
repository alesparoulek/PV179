using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;
using JobsPortal.Infrastructure.Query.Predicates;
using JobsPortal.Infrastructure.Query.Predicates.Operators;

namespace JobsPortal.BusinessLayer.QueryObjects
{
    public class ApplicationQueryObject : QueryObjectBase<ApplicationDto, Application, ApplicationFilterDto, IQuery<Application>>
    {
        public ApplicationQueryObject(IMapper mapper, IQuery<Application> query) : base(mapper, query) { }

        protected override IQuery<Application> ApplyWhereClause(IQuery<Application> query, ApplicationFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
            AddIfDefined(FilterJobOfferState(filter), definedPredicates);
            AddIfDefined(FilterUser(filter), definedPredicates);
            AddIfDefined(FilterJobOffer(filter), definedPredicates);
            if (definedPredicates.Count == 0)
            {
                return query;
            }
            if (definedPredicates.Count == 1)
            {
                return query.Where(definedPredicates.First());
            }
            var wherePredicate = new CompositePredicate(definedPredicates);
            return query.Where(wherePredicate);
        }

        private SimplePredicate FilterJobOffer(ApplicationFilterDto filter)
        {
            if (filter.JobOfferId == Guid.Empty)
            {
                return null;
            }
            return new SimplePredicate(nameof(Application.JobOfferId), ValueComparingOperator.Equal, filter.JobOfferId);
        }

        private SimplePredicate FilterUser(ApplicationFilterDto filter)
        {
            if (filter.UserId == Guid.Empty)
            {
                return null;
            }
            return new SimplePredicate(nameof(Application.UserId), ValueComparingOperator.Equal, filter.UserId);
        }

        private SimplePredicate FilterJobOfferState(ApplicationFilterDto filter)
        {
            if (filter.JobOfferState == JobOfferState.None)
            {
                return null;
            }
            return new SimplePredicate(nameof(Application.JobOfferState), ValueComparingOperator.Equal,
                filter.JobOfferState);
        }

        private static void AddIfDefined(IPredicate categoryPredicate, ICollection<IPredicate> definedPredicates)
        {
            if (categoryPredicate != null)
            {
                definedPredicates.Add(categoryPredicate);
            }
        }
    }
}
