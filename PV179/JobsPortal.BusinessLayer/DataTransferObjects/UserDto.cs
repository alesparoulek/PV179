using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using System;
using Utilities.Enums;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    public class UserDto : DtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Education Education { get; set; }

        public override string ToString()
        {
            return $"User: {FirstName} {LastName}, email: {Email}, phone: {Phone}";
        }

        protected bool Equals(UserDto other)
        {
            if (!Id.Equals(Guid.Empty))
            {
                return this.Id == other.Id;
            }
            return FirstName == other.FirstName &&
                LastName == other.LastName &&
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
                Equals((UserDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ FirstName.GetHashCode();
                hashCode = (hashCode * 397) ^ LastName.GetHashCode();
                hashCode = (hashCode * 397) ^ Email.GetHashCode();
                return hashCode;
            }
        }
    }
}
