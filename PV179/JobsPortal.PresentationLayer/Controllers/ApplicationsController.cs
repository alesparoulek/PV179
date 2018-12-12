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

        public async Task<ActionResult> Index(int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as ApplicationFilterDto ??
                         new ApplicationFilterDto() { PageSize = PageSize };

            filter.RequestedPageNumber = page;
            var user = await UserFacade.GetUserAccordingToLoginAsync(User.Identity.Name);
            filter.UserId = user.Id;
            var result = await UserFacade.GetAllApplicationsForUser(filter);
            var model = InitializeApplicationListViewModel(result);

            return View("Applications", model);
        }

        private ApplicationsViewModel InitializeApplicationListViewModel(QueryResultDto<ApplicationDto, ApplicationFilterDto> result)
        {
            return new ApplicationsViewModel()
            {
                Applications = new StaticPagedList<ApplicationDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, (int)result.TotalItemsCount),
                Filter = result.Filter
            };
        }
    }
}