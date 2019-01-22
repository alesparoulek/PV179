using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using Utilities.Enums;
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

        public UserFacade UserFacade { get; set; }

        public CompanyFacade CompanyFacade { get; set; }


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

        [HttpPost]
        public async Task<ActionResult> Index(JobOfferListViewModel model)
        {
            model.Filter.PageSize = PageSize;
            Session[filterSessionKey] = model.Filter;
            var result = await JobOfferFacade.ListFilteredJobsAsync(model.Filter);
            var newModel = InitializeProductListViewModel(result);
            return View("JobOffer", newModel);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var model = new ApplyForJobModel();
            model.JobOfferDto = await JobOfferFacade.GetJobOfferByIdAsync(id);
            model.Answers = new List<string>();
            if (model.JobOfferDto.Questionnaire != null)
            {
                for (var i = 0; i < model.JobOfferDto.Questionnaire.Split('/').Length; i++)
                {
                    model.Answers.Add("");
                }
            }
            
            return View("JobOfferDetail", model);
        }
        
        [HttpPost]
        public async Task<ActionResult> Details(ApplyForJobModel applyForJobModel)
        {
            var user = new UserDto();
            if (!Request.IsAuthenticated)
            {
                var userId = await UserFacade.RegisterUser(applyForJobModel.User);
                user = await UserFacade.GetUserAccordingToId(userId);
            }
            else
            {
                user = await UserFacade.GetUserAccordingToLoginAsync(User.Identity.Name);
            }

            var applicationDto = new ApplicationDto();
            applicationDto.UserId = user.Id;
            var url = Request.UrlReferrer.AbsoluteUri;

            applicationDto.JobOfferId = Guid.Parse(url.Split('/').Last());
            if (applyForJobModel.Answers != null)
            {
                foreach (var answer in applyForJobModel.Answers)
                {
                    applicationDto.Answers += answer + '/';
                }
            }
            
            applicationDto.JobOfferState = JobOfferState.Undecided;
            applicationDto.UserState = UserState.Undecided;
            await JobOfferFacade.ConfirmApplicationAsync(applicationDto);
            return RedirectToAction("AppliedForJob");
        }

        private JobOfferListViewModel InitializeProductListViewModel(QueryResultDto<JobOfferDto, JobOfferFilterDto> result)
        {
            return new JobOfferListViewModel()
            {
                JobOffers = new StaticPagedList<JobOfferDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, (int)result.TotalItemsCount),
                Filter = result.Filter
            };
        }


        public ActionResult AppliedForJob()
        {
            return View();
        }
    }
}