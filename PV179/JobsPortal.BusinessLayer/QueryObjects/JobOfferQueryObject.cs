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
using Utilities.Enums;

namespace JobsPortal.BusinessLayer.QueryObjects
{
    public class JobOfferQueryObject : QueryObjectBase<JobOfferDto, JobOffer, JobOfferFilterDto, IQuery<JobOffer>>
    {
        public JobOfferQueryObject(IMapper mapper, IQuery<JobOffer> query) : base(mapper, query) { }

        protected override IQuery<JobOffer> ApplyWhereClause(IQuery<JobOffer> query, JobOfferFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
            AddIfDefined(FilterCompanyId(filter), definedPredicates);
            AddIfDefined(FilterJobTypes(filter), definedPredicates);
            AddIfDefined(FilterLocations(filter), definedPredicates);
            AddIfDefined(FilterTimeJobs(filter), definedPredicates);
            AddIfDefined(FilterEducation(filter), definedPredicates);
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

        private SimplePredicate FilterCompanyId(JobOfferFilterDto filter)
        {
            if (filter.CompanyId == Guid.Empty)
            {
                return null;
            }
            return new SimplePredicate(nameof(JobOffer.CompanyId), ValueComparingOperator.Equal, filter.CompanyId);
        }

        private static void AddIfDefined(IPredicate categoryPredicate, ICollection<IPredicate> definedPredicates)
        {
            if (categoryPredicate != null)
            {
                definedPredicates.Add(categoryPredicate);
            }
        }

        private static SimplePredicate FilterJobTypes(JobOfferFilterDto filter)
        {
            if (filter.JobType == JobType.Any )
            {
                return null;
            }
            return new SimplePredicate(nameof(JobOffer.JobType), ValueComparingOperator.Equal,
                filter.JobType);
        }

        private static SimplePredicate FilterTimeJobs(JobOfferFilterDto filter)
        {
            if (filter.TimeJob == TimeJob.Any )
            {
                return null;
            }

            return new SimplePredicate(nameof(JobOffer.TimeJob), ValueComparingOperator.Equal,
                filter.TimeJob);
        }

        private static SimplePredicate FilterLocations(JobOfferFilterDto filter)
        {
            if (filter.Location == Location.Any)
            {
                return null;
            }
            return new SimplePredicate(nameof(JobOffer.Location), ValueComparingOperator.Equal,
                filter.Location);
        }

        private static SimplePredicate FilterEducation(JobOfferFilterDto filter)
        {
            if (filter.Education == Education.Any)
            {
                return null;
            }
            return new SimplePredicate(nameof(JobOffer.Education), ValueComparingOperator.Equal,
                filter.Education);
        }
    }
}
