using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobsPortal.PresentationLayer.Controllers
{
    [Authorize(Roles = "Company")]
    public class CompaniesController : Controller
    {
        // GET: Companies
        public ActionResult Register()
        {
            return View();
        }

        public async Task<ActionResult> JobOffer()
        {
            throw new NotImplementedException();
        }
    }
}