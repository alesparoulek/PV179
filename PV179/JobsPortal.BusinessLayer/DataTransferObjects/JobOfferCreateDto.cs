using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    public class JobOfferCreateDto : DtoBase
    {
        public Guid CompanyId { get; set; }
        public JobType JobType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeJob TimeJob { get; set; }
        public Location Location { get; set; }
        public Education Education { get; set; }
        public int Salary { get; set; }
        public string Questionnaire { get; set; }
        public DateTime Date { get; set; }
    }
}
