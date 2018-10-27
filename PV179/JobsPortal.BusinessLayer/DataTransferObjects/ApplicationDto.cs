using System;
using System.Collections.Generic;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    class ApplicationDto : DtoBase
    {
        public Guid JobOfferId { get; set; }
        public Guid UserId { get; set; }
        public List<string> Answers { get; set; }
        public JobOfferState JobOfferState { get; set; }
        public UserState UserState { get; set; }

        public override string ToString()
        {
            return $"Application by {UserId} on {JobOfferId}";
        }

        protected bool Equals(ApplicationDto other)
        {
            if (!Id.Equals(Guid.Empty))
            {
                return this.Id == other.Id;
            }
            return JobOfferId == other.JobOfferId &&
                   UserId == other.UserId;
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
                Equals((ApplicationDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ JobOfferId.GetHashCode();
                hashCode = (hashCode * 397) ^ UserId.GetHashCode();
                return hashCode;
            }
        }
    }
}
