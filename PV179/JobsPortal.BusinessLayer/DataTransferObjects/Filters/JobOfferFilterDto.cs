using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.DataTransferObjects.Filters
{
    public class JobOfferFilterDto : FilterDtoBase
    {
        public JobType[] JobType { get; set; }
        public TimeJob[] TimeJob { get; set; }
        public Location[] Location { get; set; }
        public Education Education { get; set; }
    }
}
