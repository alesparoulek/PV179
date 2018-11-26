using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.PresentationLayer.Models;
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
            var model = InitializeProductListViewModel(result);
            return View("JobOffer", model);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var model = await JobOfferFacade.GetJobOfferByIdAsync(id);
            return View("JobOfferDetail", model);
        }

        private JobOfferListViewModel InitializeProductListViewModel(QueryResultDto<JobOfferDto, JobOfferFilterDto> result)
        {
            return new JobOfferListViewModel()
            {
                JobOffers = new StaticPagedList<JobOfferDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, (int)result.TotalItemsCount),
                Filter = result.Filter
            };
        }


    }
}