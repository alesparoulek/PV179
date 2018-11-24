using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobsPortal.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public UserFacade UserFacade { get; set; }

        public ActionResult Index()
        {
            return View();
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
                ModelState.AddModelError("Email", "Account with that email already exists!");
                return View();
            }
        }


        /*
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisteredUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            
            RegisteredUserDto newUser = new RegisteredUserDto { Login = model.Login,
                                                                Password = model.Password,
                                                                FirstName = model.FirstName,
                                                                LastName = model.LastName,
                                                                Email = model.Email,
                                                                Phone = model.Phone,
                                                                Education = model.Education };

            Guid result = UserFacade.RegisterUser(newUser, out bool success);
            if (success)
            {
                //return RedirectToAction("RegistrationDone");
                return Content($"Created {newUser.FirstName} {newUser.LastName}");
            }
            //return RedirectToAction("RegistrationFail");
            return Content("ALREADY EXISTS WTF");
        }*/


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