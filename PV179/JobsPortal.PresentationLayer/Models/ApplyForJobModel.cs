using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobsPortal.BusinessLayer.DataTransferObjects;

namespace JobsPortal.PresentationLayer.Models
{
    public class ApplyForJobModel
    {
        public JobOfferDto JobOfferDto { get; set; }
        public List<string> Answers { get; set; }
    }
}