using Microsoft.AspNetCore.Identity;
using Part01.Models.AAA;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Models.Services
{
    public class UsernameNotInPasswordValidator : IPasswordValidator<UserApp>
    {
        public virtual async Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user, string password)
        {
            var errors = new List<IdentityError>();
            if (password.Contains(user.UserName))
            {
                errors.Add(new IdentityError
                {
                    Code = "UsernameNotInPassword",
                    Description = "رمز عبور نباید شامل نام کاربری باشد"
                });
            }
            var result = errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
            return await Task.FromResult(result);
        }
    }
    public class BlackListItemValidator : UsernameNotInPasswordValidator
    {
        private readonly AAADbContext _db;
        public BlackListItemValidator(AAADbContext db)
        {
            _db = db;
        }
        public async override Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user, string password)
        {
            var result = await base.ValidateAsync(manager, user, password);
            var errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            foreach (var item in _db.BlackLists)
            {
                if (item.Password == password)
                {
                    errors.Add(new IdentityError 
                    {
                        Code = "BlackListItem",
                        Description = "رمز عبور انتخابی قابل قبول نمی باشد"
                    });
                }
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
