using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179.entities
{
    public class RegisteredUser : User
    {
        [NotMapped]
        public override string TableName { get; } = nameof(JobsPortalDbContext.RegisteredUsers);

        [Required, MaxLength(64)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Application> Applications { get; set; }
    }
}
