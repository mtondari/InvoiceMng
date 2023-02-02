using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Account
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
            :base()
        {

        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور با تکرار رمز عبور یکسان نمی باشد.")]
        public string ConfirmPassword { get; set; }
    }
}
