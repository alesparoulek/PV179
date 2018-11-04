using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.DataTransferObjects.Filters
{
    public class ApplicationFilterDto : FilterDtoBase
    {
        public JobOfferState JobOfferState { get; set; }
        public Guid JobOfferId { get; set; }
        public Guid UserId { get; set; }
    }
}
