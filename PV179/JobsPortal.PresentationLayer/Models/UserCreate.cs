using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsPortal.PresentationLayer.Models
{
    public class UserCreate
    {
        [Required(ErrorMessage = "Required field")]
        [DisplayName("Login")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Invalid login (only alphanumeric and _)")]
        [StringLength(64, ErrorMessage = "Maximum 64 charecters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Password")]
        [RegularExpression(@"^.{8,}$", ErrorMessage = "Minimum 8 characters required")]
        [StringLength(64, ErrorMessage = "Maximum 64 charecters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("First name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid name")]
        [StringLength(64, ErrorMessage = "Maximum 64 charecters exceeded")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid name")]
        [StringLength(64, ErrorMessage = "Maximum 64 charecters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Education")]
        public Education Education { get; set; }
    }
}