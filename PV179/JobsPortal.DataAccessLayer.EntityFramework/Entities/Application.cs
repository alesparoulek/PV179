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
