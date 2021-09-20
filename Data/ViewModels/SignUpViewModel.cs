using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApi.Data.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [MinLength(2), MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Login")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter login")]
        [MinLength(2), MaxLength(255)]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(6), MaxLength(255)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
