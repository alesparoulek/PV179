using JobsPortal.Infrastructure;
using PV179.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179.entities
{
    public class User : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public virtual string TableName { get; } = nameof(JobsPortalDbContext.Users);

        [Required, MaxLength(64)]
        public string FirstName { get; set; }

        [Required, MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
        public Education Education { get; set; }
        
    }
}
