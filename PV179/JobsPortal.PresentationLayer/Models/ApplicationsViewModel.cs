using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobsPortal.BusinessLayer.DataTransferObjects;
using Utilities.Enums;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using X.PagedList;

namespace JobsPortal.PresentationLayer.Models
{
    public class ApplicationsViewModel
    {
        public IPagedList<ApplicationDto> Applications { get; set; }
        public List<JobOfferDto> JobOffers { get; set; }
        public List<UserDto> Users { get; set; }
        public string[] ApplicationSortCriteria => new[] { nameof(ApplicationDto.JobOfferState) };
        public JobOfferState JobOfferState { get; set; }
        public ApplicationFilterDto Filter { get; set; }
        public SelectList AllSortCriteria => new SelectList(ApplicationSortCriteria);
    }
}