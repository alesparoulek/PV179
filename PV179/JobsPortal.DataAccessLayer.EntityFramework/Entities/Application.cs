using JobsPortal.Infrastructure;
using JobsPortal.DataAccessLayer.EntityFramework.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsPortal.DataAccessLayer.EntityFramework.Entities
{
    public class Application : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(JobsPortalDbContext.Applications);

        [ForeignKey(nameof(JobOffer))]
        public Guid JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public List<string> Answers { get; set; }
        public JobOfferState JobOfferState { get; set; }
        public UserState UserState { get; set; }
    }
}
