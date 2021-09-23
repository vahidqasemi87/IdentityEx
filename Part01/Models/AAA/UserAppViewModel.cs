using System.ComponentModel.DataAnnotations;

namespace Part01.Models.AAA
{
    public class UserAppViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Username { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        [EmailAddress(ErrorMessage = "قالب ایمیل صحیح نمی باشد")]
        public string Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string Password { get; set; }
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "{0} اجباری می باشد")]
        public string SNN { get; set; }

    }
}
