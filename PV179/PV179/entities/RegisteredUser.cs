using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179.entities
{
    public class RegisteredUser : User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Application> Applications { get; set; }
    }
}
