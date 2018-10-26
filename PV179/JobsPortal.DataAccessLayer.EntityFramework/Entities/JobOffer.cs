using PV179.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PV179.entities
{
    public class JobOffer : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }        
        public virtual Company Company { get; set; }

        public JobType JobType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeJob TimeJob { get; set; }
        public Location Location { get; set; }
        public Education Education { get; set; }
        public int Salary { get; set; }
        public List<string> Questionnaire { get; set; }
        public virtual List<Application> Applications { get; set; }
        public DateTime Date { get; set; }
    }
}
