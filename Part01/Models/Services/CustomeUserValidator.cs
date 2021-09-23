using Microsoft.AspNetCore.Identity;
using Part01.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Models.Services
{
    public class CustomeUserValidator : UserValidator<UserApp>
    {
        public async override Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user)
        {
            var result = await base.ValidateAsync(manager, user);
            var errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            if (!user.Email.EndsWith("@nikamooz.com"))
            {
                errors.Add(new IdentityError
                {
                    Code = "CustomeUserValidator",
                    Description = "از ایمیل سازمانی استفاده کنید\n @nikamooz.com"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}