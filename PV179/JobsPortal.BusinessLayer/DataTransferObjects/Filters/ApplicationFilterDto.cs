using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace JobsPortal.BusinessLayer.DataTransferObjects.Filters
{
    public class ApplicationFilterDto : FilterDtoBase
    {
        public JobOfferState JobOfferState { get; set; }
        public Guid JobOfferId { get; set; }
        public Guid UserId { get; set; }
    }
}
