using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;

namespace JobsPortal.BusinessLayer.DataTransferObjects
{
    public class CompanyCreateDto : DtoBase
    {

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Name")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Invalid login (only alphanumeric and _)")]
        [StringLength(64, ErrorMessage = "Maximum 64 characters exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Login")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Invalid login (only alphanumeric and _)")]
        [StringLength(64, ErrorMessage = "Maximum 64 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Password")]
        [RegularExpression(@"^.{8,}$", ErrorMessage = "Minimum 8 characters required")]
        [StringLength(64, ErrorMessage = "Maximum 64 characters")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
