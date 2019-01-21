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
    [Authorize(Roles = "User")]
    public class ApplicationsController : Controller
    {
        public const int PageSize = 10;

        private readonly string pageNumberSessionKey = "pageNumber";

        private readonly string filterSessionKey = "filter";

        public UserFacade UserFacade { get; set; }

        public JobOfferFacade JobOfferFacade { get; set; }

        public async Task<ActionResult> Index(int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as ApplicationFilterDto ??
                         new ApplicationFilterDto() { PageSize = PageSize };

            filter.RequestedPageNumber = page;
            var user = await UserFacade.GetUserAccordingToLoginAsync(User.Identity.Name);
            filter.UserId = user.Id;
            var result = await UserFacade.GetAllApplicationsForUser(filter);
            var model = await InitializeApplicationListViewModel(result);

            return View("Applications", model);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var model = new ApplicationDetailsViewModel();
            model.Application = await JobOfferFacade.GetApplicationById(id);
            model.JobOffer = await JobOfferFacade.GetJobOfferByIdAsync(model.Application.JobOfferId);
            return View("Details", model);
        }

        [HttpPost]
        public async Task<ActionResult> Details(ApplicationDetailsViewModel model)
        {
            var url = Request.UrlReferrer.AbsoluteUri;

            var applicationId = Guid.Parse(url.Split('/').Last());
            await UserFacade.ChangeApplicationUserState(applicationId, model.Application.UserState);
            return View("ChangesSaved");
        }

        private async Task<ApplicationsViewModel> InitializeApplicationListViewModel(QueryResultDto<ApplicationDto, ApplicationFilterDto> result)
        {
            var model =  new ApplicationsViewModel()
            {
                Applications = new StaticPagedList<ApplicationDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, (int)result.TotalItemsCount),
                Filter = result.Filter
            };
            model.JobOffers = new List<JobOfferDto>();
            for(int i = 0; i < model.Applications.Count; i++)
            {
                var jobOffer = await JobOfferFacade.GetJobOfferByIdAsync(model.Applications[i].JobOfferId);
                model.JobOffers.Add(jobOffer);
            }

            return model;
        }
    }
}