using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.DataTransferObjects.Filters
{
    public class RegisteredUserFilterDto : FilterDtoBase
    {
        public string Email { get; set; }

        public string Login { get; set; }
    }
}
