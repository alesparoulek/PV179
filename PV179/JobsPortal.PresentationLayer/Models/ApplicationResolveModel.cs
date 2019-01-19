using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobsPortal.BusinessLayer.DataTransferObjects;

namespace JobsPortal.PresentationLayer.Models
{
    public class ApplicationResolveModel
    {
        public UserDto User { get; set; }
        public JobOfferDto JobOfferDto { get; set; }
        public ApplicationDto Application { get; set; }
    }
}