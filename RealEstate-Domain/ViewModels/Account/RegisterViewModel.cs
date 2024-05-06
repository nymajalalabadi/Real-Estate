using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "لطفا نام کامل خود را وارد کنید")]
        [MaxLength(100, ErrorMessage = "نام کامل شما نمی تواند از 100 کاراکتر بیشتر باشد")]
        public string FullName { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
