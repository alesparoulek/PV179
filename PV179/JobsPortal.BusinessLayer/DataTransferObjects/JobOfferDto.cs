using System;
using System.Collections.Generic;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using Utilities.Enums;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    public class JobOfferDto : DtoBase
    {
        public Guid CompanyId { get; set; }
        public JobType JobType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeJob TimeJob { get; set; }
        public Location Location { get; set; }
        public Education Education { get; set; }
        public int Salary { get; set; }
        public string Questionnaire { get; set; }
        public virtual List<Application> Applications { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"JobOffer by {CompanyId}, issued at: {Date}";
        }

        protected bool Equals(JobOfferDto other)
        {
            if (!Id.Equals(Guid.Empty))
            {
                return this.Id == other.Id;
            }
            return Date.Equals(other.Date) &&
                Name == other.Name &&
                CompanyId == other.CompanyId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == this.GetType() &&
                Equals((JobOfferDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                hashCode = (hashCode * 397) ^ Name.GetHashCode();
                hashCode = (hashCode * 397) ^ CompanyId.GetHashCode();
                return hashCode;
            }
        }
    }
}
