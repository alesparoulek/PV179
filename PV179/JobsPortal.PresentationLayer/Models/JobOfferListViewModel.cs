using JobsPortal.BusinessLayer.DataTransferObjects;
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
        public string[] JobOfferSortCriteria => new[] { nameof(JobOfferDto.JobType), nameof(JobOfferDto.Location), nameof(JobOfferDto.Education) };

        public IPagedList<JobOfferDto> Products { get; set; }

        public JobOfferFilterDto Filter { get; set; }

        public SelectList AllSortCriteria => new SelectList(JobOfferSortCriteria);
    }
}