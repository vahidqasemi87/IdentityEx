using Microsoft.AspNetCore.Identity;
using Part01.Models.AAA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Part01.Models.Services
{
    public class EmailNotInPasswordValidator : IPasswordValidator<UserApp>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user, string password)
        {
            var errors = new List<IdentityError>();
            if (password.Contains(user.Email))
            {
                errors.Add(new IdentityError 
                {
                    Code = "EmailNotInPassword",
                    Description = "رمز عبور نباید شامل ایمیل باشد"
                });
            }
            return await Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
