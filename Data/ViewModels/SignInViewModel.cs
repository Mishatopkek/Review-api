using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApi.Data.ViewModels
{
    public class SignInViewModel
    {

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
    }
}
