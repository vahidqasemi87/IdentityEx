using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Part01.Models.AAA;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part01.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var model = _userManager.Users;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new UserAppViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserAppViewModel inputViewModel)
        {
            if (!ModelState.IsValid)
                return View(inputViewModel);
            var user = new UserApp
            {
                UserName = inputViewModel.Username,
                Email = inputViewModel.Email,
                SNN = inputViewModel.SNN
            };
            var resultCreate = await _userManager.CreateAsync(user, inputViewModel.Password);
            if (resultCreate.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (var error in resultCreate.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(inputViewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id));
            if (!user.Succeeded)
            {
                foreach (var error in user.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var listRole = _roleManager.Roles.ToList();
            var model = new EditUserRolesViewModel
            {
                Username = user.UserName,
                UserId = user.Id,
                Roles = listRole,
                UserRoles = roles.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRoles(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var currentRole = await _userManager.GetRolesAsync(user);
            foreach (var item in currentRole)
            {
                if (!roles.Any(c => c == item))
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, item);
                }
            }
            foreach (var item in roles)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, item);
                if (!isInRole)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, item);
                }
            }
            return RedirectToAction("Index");
        }
    }
}