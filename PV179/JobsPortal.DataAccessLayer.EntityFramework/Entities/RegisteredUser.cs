using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsPortal.DataAccessLayer.EntityFramework.Entities
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
