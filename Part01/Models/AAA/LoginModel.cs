using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Models.AAA
{
    //1
    public class LoginModel
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Username { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string RedirectUrl { get; set; }
    }
}