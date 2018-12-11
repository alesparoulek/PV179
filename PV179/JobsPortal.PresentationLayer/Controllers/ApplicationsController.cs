using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsPortal.PresentationLayer.Controllers
{
    [Authorize(Roles = "User")]
    public class ApplicationsController : Controller
    {
       
        public ActionResult Index()
        {
            return View("Applications");
        }
    }
}