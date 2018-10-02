using PV179.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179.entities
{
    public class JobOffer
    {
        public int Id { get; set; }
        public JobType JobType { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public TimeJob TimeJob { get; set; }
        public int Salary { get; set; }
        public List<string> Questionnaire { get; set; }
        public Education Education { get; set; }
        public List<Application> Applications { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }
    }
}
