﻿using JobsPortal.BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetCompanyAccordingToNameAsync(string name);
    }

   
   
}