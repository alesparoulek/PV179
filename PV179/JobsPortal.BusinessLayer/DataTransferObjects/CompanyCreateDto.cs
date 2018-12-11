using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    public class CompanyCreateDto : DtoBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
