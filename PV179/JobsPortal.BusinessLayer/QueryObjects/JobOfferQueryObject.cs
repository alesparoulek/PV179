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
    public class JobOfferQueryObject : QueryObjectBase<JobOfferDto, JobOffer, JobOfferFilterDto, IQuery<JobOffer>>
    {
        public JobOfferQueryObject(IMapper mapper, IQuery<JobOffer> query) : base(mapper, query) { }

        protected override IQuery<JobOffer> ApplyWhereClause(IQuery<JobOffer> query, JobOfferFilterDto filter)
        {
            var definedPredicates = new List<IPredicate>();
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

        private static void AddIfDefined(IPredicate categoryPredicate, ICollection<IPredicate> definedPredicates)
        {
            if (categoryPredicate != null)
            {
                definedPredicates.Add(categoryPredicate);
            }
        }

        private static CompositePredicate FilterJobTypes(JobOfferFilterDto filter)
        {
            if (filter.JobType == null || !filter.JobType.Any())
            {
                return null;
            }
            var jobTypePredicates = new List<IPredicate>(filter.JobType
                .Select(jobType => new SimplePredicate(
                    nameof(filter.JobType),
                    ValueComparingOperator.Equal,
                    jobType)));
            return new CompositePredicate(jobTypePredicates, LogicalOperator.OR);
        }

        private static CompositePredicate FilterTimeJobs(JobOfferFilterDto filter)
        {
            if (filter.TimeJob == null || !filter.TimeJob.Any())
            {
                return null;
            }
            var timeJobPredicates = new List<IPredicate>(filter.TimeJob
                .Select(timeJob => new SimplePredicate(
                    nameof(filter.TimeJob),
                    ValueComparingOperator.Equal,
                    timeJob)));
            return new CompositePredicate(timeJobPredicates, LogicalOperator.OR);
        }

        private static CompositePredicate FilterLocations(JobOfferFilterDto filter)
        {
            if (filter.Location == null || !filter.Location.Any())
            {
                return null;
            }
            var locationPredicates = new List<IPredicate>(filter.Location
                .Select(location => new SimplePredicate(
                    nameof(filter.Location),
                    ValueComparingOperator.Equal,
                    location)));
            return new CompositePredicate(locationPredicates, LogicalOperator.OR);
        }

        private static SimplePredicate FilterEducation(JobOfferFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Education.ToString()))
            {
                return null;
            }
            return new SimplePredicate(nameof(JobOffer.Education), ValueComparingOperator.Equal,
                filter.Education);
        }
    }
}
