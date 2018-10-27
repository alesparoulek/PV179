using JobsPortal.DataAccessLayer.EntityFramework.Enums;
using JobsPortal.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JobsPortal.DataAccessLayer.EntityFramework.Entities
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
