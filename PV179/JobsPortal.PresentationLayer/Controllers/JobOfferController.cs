using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.Facades;
using X.PagedList;


namespace JobsPortal.PresentationLayer.Controllers
{
    public class JobOfferController : Controller
    {
        public const int PageSize = 10;

        private readonly string pageNumberSessionKey = "pageNumber";

        private readonly string filterSessionKey = "filter";
       


        public JobOfferFacade JobOfferFacade { get; set; }

        public async Task<ActionResult> Index(int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as JobOfferFilterDto ??
                       new JobOfferFilterDto() { PageSize = PageSize };
           
            filter.RequestedPageNumber = page;
            
            var result = await JobOfferFacade.ListFilteredJobsAsync(filter);
            return View("JobOffer");
        }

    }
}