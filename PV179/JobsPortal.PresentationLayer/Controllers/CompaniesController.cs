using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.PresentationLayer.Models;
using X.PagedList;

namespace JobsPortal.PresentationLayer.Controllers
{
   
    public class CompaniesController : Controller
    {
        public CompanyFacade CompanyFacade { get; set; }

        public const int PageSize = 10;

        private readonly string pageNumberSessionKey = "pageNumber";

        private readonly string filterSessionKey = "filter";

        public JobOfferFacade JobOfferFacade { get; set; }

        public UserFacade UserFacade { get; set; }



        public ActionResult Register()
        {
            return View();
        }

        public ActionResult JobOfferCreated()
        {
            return View();
        }

        public async Task<ActionResult> JobOffers(int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as JobOfferFilterDto ??
                       new JobOfferFilterDto() { PageSize = PageSize };

            filter.RequestedPageNumber = page;
            var comp = await CompanyFacade.GetCompanyAccordingToNameAsync(User.Identity.Name);
            filter.CompanyId = comp.Id;

            var result = await JobOfferFacade.ListFilteredJobsAsync(filter);
            var model = InitializeJobOfferListViewModel(result);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> JobOffers(JobOfferListViewModel model)
        {
            model.Filter.PageSize = PageSize;
            Session[filterSessionKey] = model.Filter;
            var result = await JobOfferFacade.ListFilteredJobsAsync(model.Filter);
            var newModel = InitializeJobOfferListViewModel(result);
            return View(newModel);
        }

        //----------------------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult> ApplicationsForJobOffer(ApplicationsViewModel model)
        {
            model.Filter.PageSize = PageSize;
            Session[filterSessionKey] = model.Filter;
            var result = await JobOfferFacade.GetAllApplicationsOfJobOffer(model.Filter);
            var newModel = InitializeApplicationListViewModel(result);
            return View("Applications", newModel);
        }

        public async Task<ActionResult> ApplicationsForJobOffer(Guid id, int page = 1)
        {
            Session[pageNumberSessionKey] = page;
            var filter = Session[filterSessionKey] as ApplicationFilterDto ??
                       new ApplicationFilterDto() { PageSize = PageSize };

            filter.RequestedPageNumber = page;
            filter.JobOfferId = id;

            var result = await JobOfferFacade.GetAllApplicationsOfJobOffer(filter);
            var model = InitializeApplicationListViewModel(result);

            return View("Applications", model);
        }
        //----------------------------------------------------------------------------

        public async Task<ActionResult> ApplicationResolve(Guid id)
        {
            var model = new ApplicationResolveModel();
            model.Application = await JobOfferFacade.GetApplicationById(id);
            model.JobOfferDto = await JobOfferFacade.GetJobOfferByIdAsync(model.Application.JobOfferId);
            model.User = await UserFacade.GetUserAccordingToId(model.Application.UserId);
            
            return View("ApplicationResolve", model);
        }

        [HttpPost]
        public async Task<ActionResult> ApplicationResolve(ApplicationResolveModel model)
        {
            var application = JobOfferFacade.GetApplicationById(model.Application.Id);
            await CompanyFacade.ChangeApplicationJobOfferState(model.Application.Id, model.Application.JobOfferState);
            return RedirectToAction("ChangesSaved");
        }

        private ApplicationsViewModel InitializeApplicationListViewModel(QueryResultDto<ApplicationDto, ApplicationFilterDto> result)
        {
            return new ApplicationsViewModel()
            {
                Applications = new StaticPagedList<ApplicationDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, (int)result.TotalItemsCount),
                Filter = result.Filter
            };
        }

        private JobOfferListViewModel InitializeJobOfferListViewModel(QueryResultDto<JobOfferDto, JobOfferFilterDto> result)
        {
            return new JobOfferListViewModel()
            {
                JobOffers = new StaticPagedList<JobOfferDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, (int)result.TotalItemsCount),
                Filter = result.Filter
            };
        }

        [HttpPost]
        public async Task<ActionResult> Register(CompanyCreateDto companyCreateDto)
        {
            try
            {
                await CompanyFacade.RegisterCompany(companyCreateDto);


                return RedirectToAction("RegistrationDone", "Home");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("", "Company with that username already exists!");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            (bool success, string roles) = await CompanyFacade.Login(model.Username, model.Password);
            if (success)
            {
                //FormsAuthentication.SetAuthCookie(model.Username, false);

                var authTicket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                var decodedUrl = "";
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    decodedUrl = Server.UrlDecode(returnUrl);
                }

                if (Url.IsLocalUrl(decodedUrl))
                {
                    return Redirect(decodedUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Wrong username or password!");
            return View();
        }



        [Authorize(Roles = "Company")]
        public async Task<ActionResult> CreateJobOffer()
        {
            return View();
        }

        [Authorize(Roles = "Company")]
        [HttpPost]
        public async Task<ActionResult> CreateJobOffer(JobOfferCreateDto jobOfferCreateDto)
        {
            var company = await CompanyFacade.GetCompanyAccordingToLoginAsync(User.Identity.Name);
            jobOfferCreateDto.CompanyId = company.Id;
            await CompanyFacade.CreateJobOffer(jobOfferCreateDto);
            return RedirectToAction("JobOfferCreated");

        }

        public ActionResult ChangedSaved()
        {
            return View();
        }

    }
}