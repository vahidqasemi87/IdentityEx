using Microsoft.AspNetCore.Identity;
using Part01.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Models.Services
{
    public class BlackListValidator : IPasswordValidator<UserApp>
    {
        private readonly AAADbContext _db;
        public BlackListValidator(AAADbContext db)
        {
            _db = db;
        }
        public async Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user, string password)
        {
            var errors = new List<IdentityError>();
            foreach (var item in _db.BlackLists)
            {
                if (item.Password == password)
                {
                    errors.Add(new IdentityError
                    {
                        Code = "BlackList",
                        Description = "رمز عبور انتخابی جزو موارد غیر مجاز می باشد"
                    });
                }
            }
            return await Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
