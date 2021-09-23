using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Part01.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var model = _roleManager.Roles.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = new CreateRoleViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);
            var role = new IdentityRole
            {
                Name = inputModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(inputModel);
            }
            
        }
    }
}