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
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(JobOffer))]
        public int JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public List<string> Answers { get; set; }
        public JobOfferState JobOfferState { get; set; }
        public UserState UserState { get; set; }
    }
}
