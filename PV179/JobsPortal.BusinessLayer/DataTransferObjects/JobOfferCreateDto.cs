using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using Utilities.Enums;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    public class JobOfferCreateDto : DtoBase
    {
        public Guid CompanyId { get; set; }
        public JobType JobType { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Name")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(64, ErrorMessage = "Maximum 64 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Description")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(1000, ErrorMessage = "Maximum 1000 characters")]
        public string Description { get; set; }

        public TimeJob TimeJob { get; set; }
        public Location Location { get; set; }
        public Education Education { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Salary")]
        public int Salary { get; set; }

        public string Questionnaire { get; set; }
        public DateTime Date { get; set; }
    }
}
