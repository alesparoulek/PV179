﻿using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.Facades;
using JobsPortal.PresentationLayer.Models;

namespace JobsPortal.PresentationLayer.Controllers
{
   
    public class CompaniesController : Controller
    {
        public CompanyFacade CompanyFacade { get; set; }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CompanyCreateDto companyCreateDto)
        {
            await CompanyFacade.RegisterCompany(companyCreateDto);


            return RedirectToAction("RegistrationDone", "Home");
            /*try
            {
                await CompanyFacade.RegisterCompany(companyCreateDto);


                return RedirectToAction("RegistrationDone", "Home");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("", "Company with that username already exists!");
                return View();
            }*/
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
            return View();
        }
    }
}