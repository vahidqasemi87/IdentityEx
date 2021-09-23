using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Models.AAA
{
    public class CreateRoleViewModel
    {
        [Display(Name ="نقش")]
        [Required(ErrorMessage ="{0} نباید خالی باشد")]
        public string RoleName { get; set; }
    }
}
