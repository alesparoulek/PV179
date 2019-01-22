using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.PresentationLayer.Models;
using X.PagedList;

namespace JobsPortal.PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        public const int PageSize = 10;

        private readonly string pageNumberSessionKey = "pageNumber";

        private readonly string filterSessionKey = "filter";

        public UserFacade UserFacade { get; set; }
        public CompanyFacade CompanyFacade { get; set; }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Users(int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as RegisteredUserFilterDto ??
                         new RegisteredUserFilterDto() { PageSize = PageSize };

            filter.RequestedPageNumber = page;
            var result = await UserFacade.GetAllUsers(filter);
            var model = new UserViewModel()
            {
                Users = new StaticPagedList<RegisteredUserDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize,
                    (int) result.TotalItemsCount),
                Filter = result.Filter
            };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Companies(int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as CompanyFilterDto ??
                         new CompanyFilterDto() { PageSize = PageSize };

            filter.RequestedPageNumber = page;
            var result = await CompanyFacade.GetAllCompanies(filter);
            var model = new CompaniesViewModel()
            {
                Companies = new StaticPagedList<CompanyDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize,
                    (int)result.TotalItemsCount),
                Filter = result.Filter
            };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UserDetails(Guid id)
        {
            var user = await UserFacade.GetUserAccordingToId(id);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> UserDetails()
        {
            var url = Request.UrlReferrer.AbsoluteUri;

            var id = Guid.Parse(url.Split('/').Last());
            await UserFacade.DeleteUser(id);
            return RedirectToAction("Users");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CompanyDetails(Guid id)
        {
            var comp = await CompanyFacade.GetCompanyAccordingToIdAsync(id);
            return View(comp);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CompanyDetails()
        {
            var url = Request.UrlReferrer.AbsoluteUri;

            var id = Guid.Parse(url.Split('/').Last());
            await CompanyFacade.DeleteCompany(id);
            return RedirectToAction("Companies");
        }
    }
}

