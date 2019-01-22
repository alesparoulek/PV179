using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.Facades;

namespace JobPortalWebApi.Controllers
{
    public class UserController : ApiController
    {
        
        public UserFacade UserFacade { get; set; }

        public async Task<IEnumerable<ApplicationDto>> Get(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var user = await UserFacade.GetUserAccordingToEmailAsync(email);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            var filter = new ApplicationFilterDto {UserId = user.Id};
            var result = await UserFacade.GetAllApplicationsForUser(filter);
            var applications = result.Items;
            foreach (var app in applications)
            {
                app.Id = Guid.Empty;
                app.JobOfferId = Guid.Empty;
                app.UserId = Guid.Empty;
               
            }
            return result.Items;
        }

      




}
}
