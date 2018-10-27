using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.Infrastructure;

namespace PV179.entities
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

        public virtual List<JobOffer> Offers { get; set; }

    }
}
