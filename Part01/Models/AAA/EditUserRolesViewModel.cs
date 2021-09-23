using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Models.AAA
{
    public class EditUserRolesViewModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public List<string> UserRoles { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
