using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{ 
    public class RegisteredUserDto : UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Application> Applications { get; set; }

        public override string ToString()
        {
            return $"Registered user: {FirstName} {LastName}, email: {Email}, phone: {Phone}";
        }
    }
}
