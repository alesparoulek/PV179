using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using X.PagedList;

namespace JobsPortal.PresentationLayer.Models
{
    public class UserViewModel
    {
        public IPagedList<RegisteredUserDto> Users { get; set; }
        public RegisteredUserFilterDto Filter { get; set; }
    }
}