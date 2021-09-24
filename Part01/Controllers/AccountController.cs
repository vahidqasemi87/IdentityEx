using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Part01.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Controllers
{
    //2
    public class AccountController : Controller
    {
        private readonly SignInManager<UserApp> _signInManager;
        public AccountController(SignInManager<UserApp> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login(string redirectUrl = "/")
        {
            return View(new LoginModel { RedirectUrl = redirectUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);

            var result = await _signInManager.PasswordSignInAsync(inputModel.Username, inputModel.Password, inputModel.RememberMe, false);
            if (result.Succeeded)
            {
                return LocalRedirect(inputModel.RedirectUrl);
            }
            ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه می باشد");
            return View(inputModel);
        }
        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("/");
        }
    }
}
