using JobsPortal.BusinessLayer.DataTransferObjects;
using Utilities.Enums;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace JobsPortal.PresentationLayer.Models
{
    public class JobOfferListViewModel
    {

        public IPagedList<JobOfferDto> JobOffers { get; set; }

        public JobOfferFilterDto Filter { get; set; }
        
    }
}