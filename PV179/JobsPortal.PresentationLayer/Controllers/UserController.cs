using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Facades;

namespace JobsPortal.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        public UserFacade UserFacade { get; set; }

        public async Task<ActionResult> Index()
        {
            var user = await UserFacade.GetUserAccordingToLoginAsync(User.Identity.Name);
            return View("Manage", user);
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserDto model)
        {
            var user = await UserFacade.GetUserAccordingToLoginAsync(User.Identity.Name);
            model.Id = user.Id;
            await UserFacade.UpdateUser(model);
            return View("ChangesSaved");
        }
    }
}