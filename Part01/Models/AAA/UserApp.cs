using Microsoft.AspNetCore.Identity;

namespace Part01.Models.AAA
{
    public class UserApp : IdentityUser
    {
        public string SNN { get; set; }
    }
}
