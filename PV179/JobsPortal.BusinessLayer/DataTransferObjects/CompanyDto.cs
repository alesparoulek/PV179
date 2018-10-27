using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    class CompanyDto : DtoBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<JobOffer> Offers { get; set; }

        public override string ToString()
        {
            return $"Company {Name}, email: {Email}";
        }

        protected bool Equals(CompanyDto other)
        {
            if (!Id.Equals(Guid.Empty))
            {
                return this.Id == other.Id;
            }
            return Name == other.Name &&
                   Email == other.Email;
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
                Equals((CompanyDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Email.GetHashCode();
                return hashCode;
            }
        }
    }
}
