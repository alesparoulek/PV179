using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobsPortal.Infrastructure;

namespace JobsPortal.DataAccessLayer.EntityFramework.Entities
{
    public class Company : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(JobsPortalDbContext.Companies);

        [Required, MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MaxLength(64)]
        public string Login { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        public string Roles { get; } = "Company";

        public virtual List<JobOffer> Offers { get; set; }

    }
}
