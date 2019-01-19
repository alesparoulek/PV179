using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JobsPortal.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public UserFacade UserFacade { get; set; }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "JobOffer");
        }

        public ActionResult Jobs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            (bool success, string roles) = await UserFacade.Login(model.Username, model.Password);
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

        [HttpPost]
        public async Task<ActionResult> Register(UserCreateDto userCreateDto)
        {
            try
            {
                await UserFacade.RegisterUser(userCreateDto);


                return RedirectToAction("RegistrationDone");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("", "Account with that username already exists!");
                return View();
            }
        }

        public ActionResult Logout()
        { 
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegistrationDone()
        {
            return View();
        }

        public ActionResult RegistrationFail()
        {
            return View();
        }
    }
}